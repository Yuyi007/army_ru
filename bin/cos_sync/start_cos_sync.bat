@echo off
set cur_dir=%CD%
cd %cur_dir%
set my_python_lib=%cur_dir%\dep\lib
set PYTHONPATH=%my_python_lib%;%PYTHONPATH%

python src/cos_sync.py
pause>nul