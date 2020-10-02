using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

 namespace MobilePhoneSearch.Helpers
{
    public static class PagingHelper
    {
       

        public static IHtmlContent PageLinks(this IHtmlHelper html, PagingInfo pagingInfo, string actionLink = null, string updateTargetId = null)
        {
            if (pagingInfo.TotalItems > 0)
            {
                if (!string.IsNullOrEmpty(actionLink))
                {
                    pagingInfo.ActionLink = actionLink;
                }
                var wrapperTag = new TagBuilder("div");
                wrapperTag.AddCssClass("row paging-container");
                var totalItems = new TagBuilder("div"); totalItems.AddCssClass("col-sm-7 total-items");
                var pagingWrap = new TagBuilder("div"); pagingWrap.AddCssClass("col-sm-5 paging-wrap");

                totalItems.InnerHtml.AppendHtml($"ჩანაწერები: {pagingInfo.CurrentPageStart} - {pagingInfo.CurrentPageEnd} / {pagingInfo.TotalItems}-დან  &nbsp;");
                var pageSizes = BuildPageSizes(pagingInfo, updateTargetId);
                totalItems.InnerHtml.AppendHtml(pageSizes);
                wrapperTag.InnerHtml.AppendHtml(totalItems);


                var result = new HtmlContentBuilder();

                if (pagingInfo.HasPreviousPage)
                {
                    result.AppendHtml(BuildPageLink(pagingInfo, pagingInfo.Page - 1, "<", updateTargetId));
                }
                if (pagingInfo.TotalPages > pagingInfo.PagingLinksCount)
                {
                    var start = pagingInfo.PagingStartLink;
                    var end = pagingInfo.PagingEndLink;
                    for (int j = start; j <= end; j++)
                    {
                        result.AppendHtml(BuildPageLink(pagingInfo, j, j.ToString(), updateTargetId));
                    }
                }
                else
                    for (int i = 1; i <= pagingInfo.TotalPages; i++)
                    {
                        result.AppendHtml(BuildPageLink(pagingInfo, i, i.ToString(), updateTargetId));
                    }
                if (pagingInfo.HasNextPage)
                {
                    result.AppendHtml(BuildPageLink(pagingInfo, pagingInfo.Page + 1, ">", updateTargetId));
                }

                var ultag = new TagBuilder("ul");
                ultag.MergeAttribute("class", "pagination");
                ultag.InnerHtml.AppendHtml(result);
                pagingWrap.InnerHtml.AppendHtml(ultag);
                wrapperTag.InnerHtml.AppendHtml(pagingWrap);
                return new HtmlString(GetHtmlString(wrapperTag));
            }
            return null;
        }

        private static IHtmlContent BuildPageLink(PagingInfo pagingInfo, int i, string text, string updateTargetId)
        {
            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", pagingInfo.GetUrl(i));
            if (!string.IsNullOrEmpty(updateTargetId))
            {
                tag.MergeAttribute("data-ajax", "true");
                tag.MergeAttribute("data-ajax-mode", "replace");
                tag.MergeAttribute("data-ajax-update", "#" + updateTargetId);
                tag.MergeAttribute("data-ajax-url", pagingInfo.GetUrl(i));
            }
            tag.InnerHtml.AppendHtml(text);

            var liTag = new TagBuilder("li");
            if (i == pagingInfo.Page)
                liTag.AddCssClass("active");
            liTag.InnerHtml.AppendHtml(GetHtmlString(tag));

            return liTag;
        }

        private static IHtmlContent BuildPageSizes(PagingInfo pagingInfo, string updateTargetId)
        {
            var innerPaginInfo = new PagingInfo
            {
                SearchModel = pagingInfo.SearchModel,
                PageSize = pagingInfo.PageSize,
                SortBy = pagingInfo.SortBy,
                SortDir = pagingInfo.SortDir,
                ActionLink = pagingInfo.ActionLink
            };

            var divTag = new TagBuilder("div");
            divTag.AddCssClass("dropup page-sizes");
            divTag.InnerHtml.AppendHtml("ჩანაწერები გვერდზე: ");

            var aTag = new TagBuilder("a");
            aTag.AddCssClass("dropdown-toggle btn btn-default");
            aTag.MergeAttribute("data-toggle", "dropdown");
            var currentSize = innerPaginInfo.PageSize;
            aTag.InnerHtml.AppendHtml(currentSize + "");

            var ultag = new TagBuilder("ul");
            ultag.AddCssClass("dropdown-menu");

            foreach (var size in Enum.GetValues(typeof(PageSizes)))
            {
                var liTag = new TagBuilder("li");
                var atg = new TagBuilder("a");
                if (currentSize == (int)size)
                {
                    liTag.AddCssClass("active");
                }
                innerPaginInfo.PageSize = (int)size;
                atg.MergeAttribute("href", innerPaginInfo.GetUrl(innerPaginInfo.Page));
                if (!string.IsNullOrEmpty(updateTargetId))
                {
                    atg.MergeAttribute("data-ajax", "true");
                    atg.MergeAttribute("data-ajax-mode", "replace");
                    atg.MergeAttribute("data-ajax-update", "#" + updateTargetId);
                    atg.MergeAttribute("data-ajax-url", innerPaginInfo.GetUrl(innerPaginInfo.Page));
                }
                atg.InnerHtml.AppendHtml(((int)size).ToString());
                liTag.InnerHtml.AppendHtml(atg);
                ultag.InnerHtml.AppendHtml(liTag);
            }
            divTag.InnerHtml.AppendHtml(aTag);
            divTag.InnerHtml.AppendHtml(ultag);
            return divTag;
        }

        private static string GetHtmlString(IHtmlContent content)
        {
            var writer = new StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }

     

    }
    public class PaginatedList<T> : List<T>
    {
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public PaginatedList(IQueryable<T> source, PagingInfo pInfo, bool filter = true)
        {
            PagingInfo = pInfo ?? new PagingInfo();

            if (source != null)
            {
                PagingInfo.TotalItems = pInfo.TotalItems > 0 ? pInfo.TotalItems : source.Count();

                var currentItems = source;

                if (filter)
                {
                    if (!string.IsNullOrEmpty(PagingInfo.SortBy))
                    {
                        var prop = typeof(T).GetProperty(PagingInfo.SortBy);
                        if (prop != null)
                        {
                            Func<T, object> order = p =>
                            {
                                return prop.GetValue(p, null);
                            };
                            source = (PagingInfo.SortDir == "desc" ? source.OrderByDescending(order) : source.OrderBy(order)).AsQueryable();
                        }
                    }
                    currentItems = source.Skip(PagingInfo.Skip).Take(PagingInfo.PageSize);
                }

                AddRange(currentItems);
                PagingInfo.CurrentPageEnd = PagingInfo.Skip + currentItems.ToList().Count();
            }
        }
        public PaginatedList(IQueryable<T> source, int currentPage, int pageSize,
            int? pagingLinksCount, string sortBy, string sortDir)
        {
            PagingInfo = new PagingInfo
            {
                SortBy = sortBy,
                SortDir = sortDir,
                Page = currentPage,
                PageSize = pageSize,
                TotalItems = source.Count(),
                PagingLinksCount = pagingLinksCount ?? 5
            };
            if (!string.IsNullOrEmpty(sortBy))
            {
                Func<T, object> order = p =>
                {
                    var prop = typeof(T).GetProperty(sortBy);
                    return prop.GetValue(p, null);
                };
                source = (sortDir == "desc" ? source.OrderByDescending(order) : source.OrderBy(order)).AsQueryable();
            }
            var currentItems = source.Skip(PagingInfo.Skip).Take(PagingInfo.PageSize);
            PagingInfo.CurrentPageEnd = PagingInfo.Skip + currentItems.Count();
            AddRange(currentItems);
        }
        //public PaginatedList(IQueryable<T> source, int currentPage, int pageSize, 
        //    int totalItems, int? pagingLinksCount, string sortBy, string sortDir)
        //{
        //    PagingInfo = new PagingInfo
        //    {
        //        SortBy = sortBy,
        //        SortDir = sortDir,
        //        CurrentPage = currentPage,
        //        PageSize = pageSize,
        //        TotalItems = totalItems,
        //        PagingLinksCount = pagingLinksCount ?? 5
        //    };
        //    AddRange(source);
        //}
    }
    public enum PageSizes
    {
        P3 = 3,
        P5 = 5,
        P10 = 10,
        P20 = 20,
        P50 = 50,
        P100 = 100
    }
    public class PagingInfo
    {
        //public string SearchUrl { get; set; }
        private string sortDir;
        public string SortDir
        {
            get
            {
                return string.IsNullOrEmpty(sortDir) ? null : sortDir.ToLower();
            }
            set { sortDir = value; }
        }
        public string SortBy { get; set; }

        public int TotalItems { get; set; }
        public int PageSize { get; set; } = 2;
        public int Page { get; set; } = 1;

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public int CurrentPageStart => Skip + 1;
        public int CurrentPageEnd { get; set; }
        public int PagingLinksCount { get; set; } = 5;
        public object SearchModel { get; set; }
        public int Skip => (Page - 1) * PageSize;

        public int PagingStartLink
        {
            get
            {
                var half = Page - PagingLinksCount / 2;
                var maxFirstLink = TotalPages - PagingLinksCount + 1;
                var asd = (half > 1) ? half : 1;
                return (asd < maxFirstLink) ? asd : maxFirstLink;
            }
        }

        public int PagingEndLink
        {
            get
            {
                var asd = PagingStartLink + PagingLinksCount - 1;
                return (asd < TotalPages) ? asd : TotalPages;
            }
        }

        public bool HasPreviousPage => (Page > 1);

        public bool HasNextPage => (Page < TotalPages);

        public string ActionLink { get; internal set; }

        public string GetUrl(int i)
        {
            var searchUrl = "?";
            if (SearchModel != null)
            {
                Type type = SearchModel.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType == typeof(List<int>))
                    {
                        var cats = (List<int>)property.GetValue(SearchModel);
                        if (cats != null)
                        {
                            foreach (var item in cats)
                            {
                                searchUrl += property.Name + "=" + item + "&";
                            }
                        }
                    }
                    else
                    {
                        if (property.GetValue(SearchModel) != null)
                        {
                            searchUrl += property.Name + "=" + property.GetValue(SearchModel) + "&";
                        }
                    }
                }
            }

            var result = "";

            if (!string.IsNullOrEmpty(SortBy))
            {
                if (searchUrl.Contains("SortBy=") || searchUrl.Contains("sortby="))
                {
                    var sb = searchUrl.Contains("SortBy=") ? "SortBy=" : "sortby";
                    searchUrl = searchUrl.Substring(0, searchUrl.IndexOf(sb));
                }

                result += "sortby=" + SortBy + "&";
                if (SortDir == "desc")
                {
                    result += "sortdir=desc&";
                }
                if (searchUrl.Contains("SortDir=") || searchUrl.Contains("sortdir="))
                {
                    var sb = searchUrl.Contains("SortDir=") ? "SortDir" : "sortdir";
                    searchUrl = searchUrl.Substring(0, searchUrl.IndexOf(sb));
                }
            }

            if (i > 0)
            {
                result += "page=" + i + "&";
            }

            PageSizes size;
            var succ = Enum.TryParse(PageSize.ToString(), out size);
            if (succ && size != PageSizes.P20 && size != 0)
            {
                result += "pagesize=" + PageSize + "&";
            }

            //var searchUrl = SearchUrl + (SearchUrl.Contains('?') ? string.Empty : "?");
            result = result.Substring(result.Length - 1) == "&" ? result.Substring(0, result.Length - 1) : result;
            if (!string.IsNullOrEmpty(result))
            {
                if (result.Substring(0, 1) == "&" && searchUrl.Substring(searchUrl.Length - 1) == "?")
                {
                    result = result.Substring(1, result.Length - 1);
                }
                result = searchUrl + result;
            }

            if (!string.IsNullOrEmpty(ActionLink))
            {
                result = ActionLink + result;
            }
            return result;
        }
    }
}
