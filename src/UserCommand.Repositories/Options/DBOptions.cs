﻿namespace UserCommand.Repositories.Options;

public class DBOptions
{
    public const string SectionKey = nameof(DBOptions);
    public string ConnectionString { get; set; }
}