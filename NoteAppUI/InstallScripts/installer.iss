; ��� ����������
#define   Name       "NoteApp"
; ������ ����������
#define   Version    "1.0.0"
; �����-�����������
#define   Publisher  "Potlog"
; ���� ����� ������������
#define   URL        "https://vk.com/spotlog"
; ��� ������������ ������
#define   ExeName    "NoteApp.exe"

[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{67AB88E3-34C1-495F-AB26-3CF16FAE88A2}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir={#SourcePath}\Installers\
OutputBaseFileName=NoteApp-setup

; ���� ������
SetupIconFile=iconNoteApp.ico

; ��������� ������
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "LICENSE.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "LICENSE.txt"

[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; ����������� ����
Source: "Release\NoteAppUI.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]

Name: "{group}\{#Name}"; Filename: "iconNoteApp.ico"

Name: "{commondesktop}\{#Name}"; Filename: "iconNoteApp.ico"; Tasks: desktopicon