import sys
import os

######################################
# Initial Parameter
DB = [[0] * 8 for _ in range(1)]
DB[0][0] = "Path"
DB[0][1] = "Filename"
DB[0][2] = "Testname"
DB[0][3] = "Group"
DB[0][4] = "Test_fw"
DB[0][5] = "Knobs"
DB[0][6] = "Cc_args"
DB[0][7] = "Sim_args"

def GET_LIST(filepath):
    getlist = []
    with open(filepath, 'r') as file:
        for line in file:
            if (":" in str(line)) and ("#" not in str(line[0])):
                getlist.append(line.strip('\n'))
    return getlist

def SORT_LIST(paths, filename, *getlist):
    if (len(getlist)):
        for i in range(len(getlist)):
            DB.append([0] * 8)
            DB[len(DB)-1][0] = paths
            DB[len(DB)-1][1] = filename
            string = getlist[i]
            index_head = string.find(":")
            DB[len(DB)-1][2] = string[0:index_head-1]
            findstring = 'group="'
            if findstring in string:
                index_head = string.find(findstring) + len(findstring)
                index_tail = string[index_head:].find('"') + index_head
                DB[len(DB)-1][3] = string[index_head:index_tail]
            # ...................................... #
            findstring = 'sim_args="'
            if findstring in string:
                index_head = string.find(findstring) + len(findstring)
                index_tail = string[index_head:].find('"') + index_head
                DB[len(DB)-1][7] = string[index_head:index_tail]

######################################
# SCRIPT START
print("# SCRIPT START #")

# Input system arguments
dir_base = 0
result_file = 0
for v in range(1, len(sys.argv)):
    if sys.argv[v] == "-h":
        print("Help Command")
        print("Usage : python *.py -d ./dir -f ./result.csv")
    elif sys.argv[v] == "-d":
        dir_base = str(sys.argv[v+1])
        print("DIR_BASE = " + dir_base)
    elif sys.argv[v] == "-f":
        result_file = str(sys.argv[v+1])
        print("RESULT_FILE = " + result_file)

# Search file as extension
if not (dir_base):
    dir_base = os.getcwd()
for (paths, dirs, files) in os.walk(dir_base):
    for filename in files:
        if filename.endswith(".testlist"):
            try:
                testist = GET_LIST(paths+"/"+filename)
                SORT_LIST(paths, filename, *testlist)
            except:
                pass

######################################
# save result to csv
if not (result_file):
    result_file = './result.csv'
with open(result_file, 'w') as file:
    for i in range(len(DB)):
        for j in range(8):
            file.write(str(DB[i][j]) + ';')
        file.write('\n')
######################################

print("# SCRIPT END #")