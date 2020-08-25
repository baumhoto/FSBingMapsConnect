#NoTrayIcon
#WinActivateForce
;#SingleInstance
if WinExist("ahk_class AceApp")
    WinActivate ; use the window found above
else
    WinActivate, FS Maps Connect

Exit