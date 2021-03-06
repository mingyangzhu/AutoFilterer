﻿using AutoFilterer.Extensions;
using AutoFilterer.Tests.Environment.Dtos;
using AutoFilterer.Tests.Environment.Models;
using AutoFilterer.Tests.Environment.Statics;
using AutoFilterer.Types;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoFilterer.Tests.Types
{
    public class OperatorQueryTests
    {
        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageWithAnd_SholdMatchCount(List<Book> data, BookFilter_OperatorFilter_TotalPage filter)
        {
            // Arrange
            filter.CombineWith = Enums.CombineType.And;

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var f = filter;
            var actualResult = GetAndQuery(data.AsQueryable(), filter).ToList();
            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
            
            IQueryable<Book> GetAndQuery(IQueryable<Book> query, BookFilter_OperatorFilter_TotalPage f)
            {
                if (f.TotalPage.Eq != null)
                    query = query.Where(x => x.TotalPage == f.TotalPage.Eq);

                if (f.TotalPage.Not != null)
                    query = query.Where(x => x.TotalPage != f.TotalPage.Not);

                if (f.TotalPage.Gt != null)
                    query = query.Where(x => x.TotalPage > f.TotalPage.Gt);

                if (f.TotalPage.Gte != null)
                    query = query.Where(x => x.TotalPage >= f.TotalPage.Gte);

                if (f.TotalPage.Lt!= null)
                    query = query.Where(x => x.TotalPage < f.TotalPage.Lt);

                if (f.TotalPage.Lte!= null)
                    query = query.Where(x => x.TotalPage <= f.TotalPage.Lt);

                return query;
            }
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageEqWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Eq = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage == totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageNotWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Not = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage != totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageGtWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Gt = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage > totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageGteWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Gte = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage >= totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageLteWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Lte = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage <= totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageLtWithAnd_ShouldMatchCount(List<Book> data, int totalPage)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Lt = totalPage, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage < totalPage).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageLtGtWithAnd_ShouldMatchCount(List<Book> data, int min, int some)
        {
            // Arrange
            var max = min + some;
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Gt = min,
                    Lt = max, 
                    CombineWith = Enums.CombineType.And
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage > min && x.TotalPage < max).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageLtGtWithOr_ShouldMatchCount(List<Book> data, int min, int some)
        {
            // Arrange
            var max = min + some;
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Gt = min,
                    Lt = max, 
                    CombineWith = Enums.CombineType.Or
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage > min || x.TotalPage < max).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }

        [Theory, AutoMoqData(count: 64)]
        public void BuildExpression_TotalPageLtEqWithOr_ShouldMatchCount(List<Book> data, int max, int exact)
        {
            // Arrange
            var filter = new BookFilter_OperatorFilter_TotalPage
            {
                TotalPage = new OperatorFilter<int>
                {
                    Eq = exact,
                    Lt = max, 
                    CombineWith = Enums.CombineType.Or
                }
            };

            // Act
            var query = data.AsQueryable().ApplyFilter(filter);
            var result = query.ToList();

            // Assert
            var actualResult = data.AsQueryable().Where(x => x.TotalPage < max || x.TotalPage == exact).ToList();

            Assert.Equal(actualResult.Count, result.Count);
            foreach (var item in actualResult)
                Assert.Contains(item, result);
        }
    }
}
