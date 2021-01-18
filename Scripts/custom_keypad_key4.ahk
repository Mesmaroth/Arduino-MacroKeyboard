#NoEnv
SendMode Input
SetWorkingDir %A_ScriptDir%

;=================================
; CUSTOM KEYPAD KEY 4
#NoTrayIcon
^!+F5::
Run, C:\Program Files\CPUID\HWMonitor\HWMonitor.exe
return