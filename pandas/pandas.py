#!/usr/bin/env python3

# 유일한 값 넣기
list = [1, 2, 1, 4, 8]
checkArray = []
for i in range(len(list)):
    if list[i] not in checkArray:
        checkArray.append(list[i])
'''>>> checkArray = [1, 2, 4, 8]'''

# 2차원배열 [row:10][column:5] 생성 후, column[0] 기준으로 정렬
dataArray = [[0]*5 for _ in range(len(10)]
dataArray[1][0] = "row-1 / column-0"
dataArray = sorted(dataArray, key=lambda dataArray: dataArray[0])

# 2차원배열 값이 없는 row 삭제 (column[2] 기준)
dataArray = [[0]*5 for _ in range(len(10)]
for i in range(len(dataArray)):
    k = len(dataArray)
    for j in range(k):
        if not (dataArray[j][2]):
            del dataArray[j]
            break
    if (j == k):
        break

# openpyxl 기본 동작
import openpyxl
excel = openpyxl.Workbook()
report = excel.active
report.title = "REPORT"
report.append(["IPName", "TestList", "TestCase"])
ipnameList = ['1.Top', '2.BUS', '3.ETC']
index = 0
row_range = report['A2':'A4']
for row in row_range:
    for cell in row:
        cell.value = ipnameList[index]
        index += 1
report[31][1].value = "=SUM(B2:B30)"
excel.save('./result.xlsx')

# pandas 기본 동작
import pandas as pd
csv_file = pd.read_csv(./*.csv)
xlsx_file = pd.read_excel(./*.xlsx)
csv_file.loc[1][0] = "row-1 / column-0"
sheet = pd.DataFrame(dataArray)
sheet[1][0] = "column-1 / row-1"
with pd.ExcelWriter("./result.xlsx") as writer:
    sheet.to_excel(writer, sheet_name="sheet1", index=False)

