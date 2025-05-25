﻿namespace AmazonKiller.Application.Common.Models;

public class PagedList<T>
{
    public List<T> Items { get; init; } = [];
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}