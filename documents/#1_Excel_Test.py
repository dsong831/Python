import openpyxl

WB = openpyxl.Workbook()

WS = WB.active
WS["A1"] = "# Create workbook by openpyxl #"
WS.append(["Number", "Item", "Comments", "Others"])
WS.cell(row=3, column=2, value="TEST OK")

WB.save("Excel_Test.xlsx")
print("Result :", WS["B3"].value)
