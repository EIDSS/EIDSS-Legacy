using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using bv.model.BLToolkit;
using eidss.openapi.bll.Exceptions;
using bv.model.Model.Core;

namespace eidss.openapi.bll.Converters
{
    internal class BaseConverter<C, M> :
        IConverter<C, M>
        where C : class 
        where M : class, IObject
    {
        public C ToContract(DbManagerProxy manager, M m)
        {
            try
            {
                return m == null ? null : Mapper.Map<C>(m);
            }
            catch (AutoMapper.AutoMapperMappingException e)
            {
                if (e.InnerException is OpenApiException)
                    throw e.InnerException;
                throw;
            }
        }

        public M ToModel(DbManagerProxy manager, M m, C c)
        {
            try
            {
                if (c != null && m != null)
                    m = Mapper.Map(c, m);
                return m;
            }
            catch (AutoMapper.AutoMapperMappingException e)
            {
                if (e.InnerException is OpenApiException)
                    throw e.InnerException;
                throw;
            }
        }
    }
}