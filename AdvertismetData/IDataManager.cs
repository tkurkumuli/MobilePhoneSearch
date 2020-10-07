using BusinessLayer.Repositories.Implementations;
using System;

namespace BusinessLayer
{
    public interface IDataManager : IDisposable
    {
        //ამას ვაკომენტარებ, აქ არ არის საჭირო. ინტერფეისი იმისთვის არის რაღაცები განაზოგადო და ეს ძაან აკონკრეტებს
        //MobileService Mobilephones { get; }
        //ManufacturerService Manufacturers { get; }

        //Unit of work-ის ინტერფეისში ზოგადად მიღებულია რომ გქონდეს Commit მეთოდი. ამ შემთხვევაში ეგ არ გჭირდება, რადგან შენი რეპოზიტორიები მხოლოდ 
        //კითულობენ მონაცემებს, მაგრამ მაინც დავამატოთ იმიტომ რო როცა პროექტს წერ აუცილებლად უნდა იფიქრო პროექტის შესაძლო განვითარებებზე და 
        //მოდი შევთანხმდეთ, რომ ეს ისეთი პროექტია, რომელსაც იდეაში უნდა ჰქონდეს მონაცემების დამატებაც (მომავალში)

        void Commit();
    }
}
