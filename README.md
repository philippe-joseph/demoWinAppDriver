# demoWinAppDriver

## Projektbeschreibung

Das Projekt `demoWinAppDriverPOM` ist eine Testautomatisierungs-Suite für die KeePass-Anwendung unter Verwendung von WinAppDriver und MSTest. Es ermöglicht das automatisierte Testen der KeePass-Anwendung durch verschiedene Testfälle und Berichterstellung.

## Projektstruktur

- `demoWinAppDriverPOM/`
  - `bin/` - Kompilierte Binärdateien.
  - `demoWinAppDriverPOM.csproj` - Projektdatei.
  - `KeePassSession.cs` - Initialisiert eine KeePass-Sitzung.
  - `MainApp.cs` - Hauptanwendungsklasse.
  - `MSTestSettings.cs` - MSTest-Einstellungen.
  - `obj/` - Objektdateien.
  - `pages/` - Enthält Page-Object-Model-Klassen.
    - `MainWindow.cs` - Repräsentiert das Hauptfenster der KeePass-Anwendung.
  - `tests/` - Enthält die Testklassen.
    - `BasicTests` - Beispielhafte Testfälle.
  - `utils/` - Dienstprogramme und Hilfsklassen.
    - `KeePassBase.cs` - Basisklasse für Tests, die den KeePass-Treiber initialisiert.
    - `ReportingUtility.cs` - Dienstprogramm für die Berichterstellung.

## Tests erweitern

Um neue Tests hinzuzufügen oder bestehende Tests zu erweitern, folgen Sie diesen Schritten:

1. **Neue Testklasse erstellen**:
   - Erstellen Sie eine neue C#-Datei im Verzeichnis `tests/`.
   - Erben Sie von der Klasse `KeePassBase`, um den KeePass-Treiber zu initialisieren.

2. **Testmethoden hinzufügen**:
   - Verwenden Sie das Attribut `[TestMethod]`, um neue Testmethoden zu definieren.
   - Nutzen Sie die vorhandenen Page-Object-Model-Klassen aus dem Verzeichnis `pages/`, um auf die KeePass-UI-Elemente zuzugreifen.

3. **Berichterstellung**:
   - Verwenden Sie die Methoden der Klasse `ReportingUtility`, um Testschritte und Ergebnisse zu protokollieren.

Beispiel:
```cs
[TestClass]
public class NewTests : KeePassBase
{
    [TestMethod]
    public void NewTest()
    {
        ReportingUtility.LogInfo("Start new test.");
        var mainWindow = new MainWindow(Driver);
        mainWindow.FocusWindow();
        // Weitere Testschritte...
    }
}