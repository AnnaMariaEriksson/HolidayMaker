﻿using HolidayMakerUWP.DAL;
using HolidayMakerUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace HolidayMakerUWP.Viewmodel
{
    
  public class HotelSearchVm
    {
        public ICommand FilterBtn { get; set; }
        public Dictionary<string, object> Filters;

        public System.Drawing.Color c1 = System.Drawing.Color.FromArgb(48, 179, 221);
        public System.Drawing.Color c2 = System.Drawing.Color.FromArgb(48, 179, 221);
        public int _distansToCenter { get; set; }
        public int _distansToBeach { get; set; }
        public int DistansToBeach { get { return _distansToBeach;  } set { FilterToggle("Test"); _distansToBeach = value; } }
        public int DistansToCenter { get {  return _distansToCenter; } set { FilterToggle("Test2"); _distansToCenter = value;  } }
        public ObservableCollection<Hotel> _hotels { get; set; }
        public ObservableCollection<Hotel> TempHotel { get; set; }

        public ObservableCollection<Hotel> Hotels
        {
            get
            {
            
                return _hotels;
            }
            set
            {
                _hotels = value;
            }
        }

        HotelsService _service;
        public HotelSearchVm()
        {

            FilterBtn = new RelayCommand<string>(FilterToggle);
            Filters = new Dictionary<string, object>();
            this._service = new HotelsService();
            _hotels = _service.GetHotels();
            TempHotel = _service.GetHotels();
        }

         public void RemoveFilteredHotels(ObservableCollection<Hotel> hotels)
        {
            

        }

        private void FilterToggle(string filter)
        {
            if (Filters.ContainsKey(filter))
            {
                Filters.Remove(filter);
            }
            else
            {
                Filters.Add(filter, true);

            }
            //return list to view
           if(Filters.Count  == 0)
            {
                Filters.Add("FilterReset", true);
            }

                var test = new ObservableCollection<Hotel>(Filter(TempHotel, Filters));

            if (Filters.FirstOrDefault(f => f.Key == "FilterReset").Key != null)
            {
                var FilterToRemove = Filters.FirstOrDefault(f => f.Key == "FilterReset").Key;
                Filters.Remove(FilterToRemove);
            }
            _hotels.Clear();
           foreach(Hotel h in test)
            {
                if(h.DistansToBeach >= DistansToBeach && h.DistansToCenter >= DistansToCenter)
                {
                    _hotels.Add(h);
                }
                
            }
            
            
            
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Dictionary<string, object> filters)
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var queryable = collection.AsQueryable();
            var instance = Expression.Parameter(type, "instance");

            var expressions = new Stack<Expression>();

            foreach (var filter in filters)
            {
                var propertyName = filter.Key;
                var property = properties.FirstOrDefault(x => x.Name == propertyName);
                if (property == null)
                    continue;

                var left = Expression.Property(instance, property);
                var right = Expression.Constant(filter.Value, property.PropertyType);
                var expr = Expression.Equal(left, right);

                expressions.Push(expr);
            }

            Expression call = null;
            Expression previousExpression = null;
            while (expressions.Count > 0)
            {
                var expr = expressions.Pop();
                if (previousExpression == null)
                {
                    previousExpression = expr;
                    call = expr;
                }
                else
                {
                    var and = Expression.AndAlso(previousExpression, expr);
                    call = and;
                    previousExpression = and;
                }
            }

            var whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { queryable.ElementType },
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(call, new[] { instance }));

            return queryable.Provider.CreateQuery<T>(whereCallExpression);
        }



    }
}