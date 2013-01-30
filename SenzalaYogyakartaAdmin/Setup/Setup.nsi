!include "nsProcess.nsh"
OutFile "Setup.exe"

installDir "$PROGRAMFILES\Swdev Bali\Senzala Yogyakarta"
!define shortcutDir "$SMPROGRAMS\Senzala Yogyakarta"
RequestExecutionLevel admin


section
	SetShellVarContext all
	setOutPath $INSTDIR
	${nsProcess::KillProcess} "SenzalaYogyakartaManajemenSiswa.exe" $R0
	File /r "source\*"
	writeUninstaller $INSTDIR\uninstaller.exe
	CreateDirectory "${shortcutDir}" 
	createShortCut "${shortcutDir}\Manajemen Siswa.lnk" "$INSTDIR\SenzalaYogyakartaManajemenSiswa.exe"
	createShortCut "${shortcutDir}\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
	
sectionEnd

	section "Uninstall"
	SetShellVarContext all
	delete "$INSTDIR\uninstaller.exe"
	RMDir /r "$INSTDIR"
	RMDir /r "${shortcutDir}"
sectionEnd