import csv
import os
import sys
import yaml, json
import datetime
import calendar
# name of data file
holiday_file_csv = '../data/syukujitsu.csv'
holiday_file_yml = '../holiday_jp/holidays_detailed.yml'

class Holiday:
 
   def __init__(self, date, week, week_en, name, name_en):
      self.date = date
      self.week = week
      self.week_en = week_en
      self.name = name
      self.name_en = name_en

weekDict = {}
holidayDict = {}
hsDict ={}

def findDay(date): 
    born = datetime.datetime.strptime(date, '%Y/%m/%d').weekday() 
    return (calendar.day_name[born])
def findDay2(date): 
    year,month,day = (int(i) for i in date.split('/'))     
    born = datetime.date(year, month, day) 
    return born.strftime("%A")
def findDay3(date): 
    year,month,day = (int(i) for i in date.split('/'))     
    dayNumber = calendar.weekday(year, month, day) 
    days =["Monday", "Tuesday", "Wednesday", "Thursday", 
                         "Friday", "Saturday", "Sunday"] 
    return (days[dayNumber])
class DateTimeEncoder(json.JSONEncoder):
    def default(self, obj):                       # pylint: disable=E0202
        if isinstance(obj, datetime.datetime):
            return obj.strftime('%Y-%m-%d %H:%M:%S')
        elif isinstance(obj, datetime.date):
            return obj.strftime('%Y-%m-%d')
        else:
            return json.JSONEncoder.default(self, obj)

with open(holiday_file_yml,'r', encoding='UTF-8') as f:
    # print(json.dumps(yaml.safe_load(f), cls=DateTimeEncoder))
    tempDict = yaml.safe_load(f)
    for h in tempDict.values():
        weekDict[h['week_en']] = h['week']
        holidayDict[h['name']] = h['name_en']

with open(holiday_file_csv,'r', encoding='Shift_JIS') as csvfile:
    csv_reader = csv.reader(csvfile) 
    next(csv_reader)
    for row in csv_reader: 
        year,month,day = (int(i) for i in row[0].split('/'))
        if year >= 1970:
            break
        tempDate = datetime.date(year, month, day)
        date = tempDate.strftime('%Y-%m-%d')
        week_en = tempDate.strftime("%A")
        week = weekDict[week_en]
        name = row[1]
        name_en = holidayDict.get(name, 'unknown')
        hsDict[date] = {'date':date,'week':week,'week_en':week_en,'name':name,'name_en':name_en}
result = json.dumps(hsDict,ensure_ascii=False)
print(result)
fo = open("h.json", "w", encoding='utf-8') 
fo.write(result)   
fo.close()

