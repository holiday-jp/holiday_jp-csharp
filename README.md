# holiday_jp-csharp
[![Build status](https://ci.appveyor.com/api/projects/status/nqfw6rowy0gaxk0c?svg=true)](https://ci.appveyor.com/project/codeyu/holiday-jp-csharp)
[![NuGet Badge](https://buildstats.info/nuget/HolidayJp)](https://www.nuget.org/packages/HolidayJp/) 
[![License](https://img.shields.io/badge/license-MIT%20License-blue.svg)](LICENSE)

[Japanese holiday](https://github.com/holiday-jp/holiday_jp) for .NET

## Install

Install with nuget:

``` sh
PM> Install-Package HolidayJp
```
.NET CLI
```sh
dotnet add package HolidayJp
```

## Usage

```cs
var holidays = HolidayJp.Between(DateTime.Parse('2019-09-14'), DateTime.Parse('2019-09-21'));
Console.WriteLine(holidays[0].Name) //敬老の日
```

```cs
var holidays = HolidayJp.SomeMonth(2019, 9);
Console.WriteLine(holidays[0].Name) //敬老の日
```

```cs
var isHoliday = HolidayJp.IsHoliday(DateTime.Parse('2019-09-16'));
Console.WriteLine(isHoliday) //true
```

```cs
var Holiday holiday;
var holiday = HolidayJp.TryGet(DateTime.Parse('2019-09-16'), out holiday);
Console.WriteLine(holiday.Name) //敬老の日
```

## Test by syukujitsu.csv

[syukujitsu.csv](data/syukujitsu.csv)

出典：[内閣府ホームページ] ( https://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html )

## License

The MIT License (MIT). Please see [License File](LICENSE) for more information.