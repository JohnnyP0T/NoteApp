; Имя приложения
#define   Name       "NoteApp"
; Версия приложения
#define   Version    "1.0.0"
; Фирма-разработчик
#define   Publisher  "Potlog"
; Сафт фирмы разработчика
#define   URL        "https://vk.com/spotlog"
; Имя исполняемого модуля
#define   ExeName    "NoteApp.exe"

[Setup]

; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{67AB88E3-34C1-495F-AB26-3CF16FAE88A2}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir={#SourcePath}\Installers\
OutputBaseFileName=NoteApp-setup

; Файл иконки
SetupIconFile=iconNoteApp.ico

; Параметры сжатия
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "LICENSE.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "LICENSE.txt"

[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Исполняемый файл
Source: "Release\NoteAppUI.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]

Name: "{group}\{#Name}"; Filename: "iconNoteApp.ico"

Name: "{commondesktop}\{#Name}"; Filename: "iconNoteApp.ico"; Tasks: desktopicon