﻿namespace HomeWork_17_Modul_3_.Models;

internal class Files
{
    public string? NameFile { get; set; } = DateTime.UtcNow.ToString("MM/dd/yyyy hh.mm.ss.ffftt");
    public string? Path { get; } = "C:\\Users\\Сім'я\\source\\repos\\HomeWork 17(Modul 3)\\HomeWork 17(Modul 3)\\Backup\\";
    public string? FullPuth { get; set; }
    public int Counter { get; set; } = 0;

    public SemaphoreSlim? SemaphoreSlim { get; set; } = new SemaphoreSlim(1);
    public StreamWriter? StreamWriter { get; set; }
}
