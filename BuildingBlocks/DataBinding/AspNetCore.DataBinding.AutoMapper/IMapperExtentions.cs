using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace AspNetCore.DataBinding.AutoMapper
{
    public static class IMapperExtentions
    {
        public static IQueryable<TDestination> MapQueryTo<TDestination>(this IMapper mapper, IQueryable source)
        {
            return source.ProjectTo<TDestination>(mapper.ConfigurationProvider);
        }
        public static IQueryable<TDestionation> MapQueryTo<TDestionation>(this IQueryable source, IMapper mapper)
        {
            return source.ProjectTo<TDestionation>(mapper.ConfigurationProvider);
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }
    }
}
