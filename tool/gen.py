import csv
import os
import sys
import yaml, json
from datetime import datetime
from datetime import date
# name of data file
holiday_file_csv = '../data/syukujitsu.csv'
holiday_file_yml = '../holiday_jp/holidays_detailed.yml'

class DateTimeEncoder(json.JSONEncoder):
    def default(self, obj):                       # pylint: disable=E0202
        if isinstance(obj, datetime):
            return obj.strftime('%Y-%m-%d %H:%M:%S')
        elif isinstance(obj, date):
            return obj.strftime('%Y-%m-%d')
        else:
            return json.JSONEncoder.default(self, obj)

with open(holiday_file_yml,'r', encoding='UTF-8') as f:
    # print(json.dumps(yaml.safe_load(f), cls=DateTimeEncoder))
    print(yaml.safe_load(f))

with open(holiday_file_csv,'r', encoding='Shift_JIS') as csvfile:
    csv_reader = csv.reader(csvfile)  # 使用csv.reader读取csvfile中的文件
    for row in csv_reader:  # 将csv 文件中的数据保存到birth_data中
        print(row)
