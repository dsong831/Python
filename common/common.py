#!/usr/bin/env python3

# 시스템 파라미터 설정
import sys
for v in range(1, len(sys.argv)):
    if sys.argv[v] == "-s":
        print(str(sys.argv[v+1]))
    elif sys.argv[v] == "-h":
        print(Help Command")

