unit GenFiles;

interface

uses Math, UrsProfiler, Dialogs, SysUtils;

type
  TRecTest = record
    symbol: char;
    number: integer;
  end;

  TestFile = File of TRecTest;
  
var
  recTest: TRecTest;

  file50: TestFile;
  file500: TestFile;
  file5000: TestFile;

  msgGen50, msgGen500, msgGen5000: string;
  msgFileSize50, msgFileSize500, msgFileSize5000: string;

  procedure GenerateRecordsAndSave;
  procedure NopP;
  function SearchRecord(number: integer; choiceFile: integer): boolean;

implementation

procedure NopP;
asm
  // nop
end;

procedure GenerateRecordsAndSave;
var
  i: integer;
begin
  AssignFile(file50, 'File50.dat');
  AssignFile(file500, 'File500.dat');
  AssignFile(file5000, 'File5000.dat');

  ReWrite(file50);
  ReWrite(file500);
  ReWrite(file5000);

  rsProfiler[1].Start;
  for i := 1 to 5000 do begin
    recTest.symbol := Char(RandomRange(33, 126));
    recTest.number := i;

    Seek(file5000, FileSize(file5000));
    Write(file5000, recTest);
  end;
  rsProfiler[1].Stop;

  rsProfiler[2].Start;
  for i := 1 to 500 do begin
    recTest.symbol := Char(RandomRange(33, 126));
    recTest.number := i;

    Seek(file500, FileSize(file500));
    Write(file500, recTest);
  end;
  rsProfiler[2].Stop;

  rsProfiler[3].Start;
  for i := 1 to 50 do begin
    recTest.symbol := Char(RandomRange(33, 126));
    recTest.number := i;

    Seek(file50, FileSize(file50));
    Write(file50, recTest);
  end;
  rsProfiler[3].Stop;

  msgFileSize50 := IntToStr( Round( FileSize(file50) * SizeOf(recTest)));
  msgFileSize500 := IntToStr( Round( FileSize(file500) * SizeOf(recTest)));
  msgFileSize5000 := IntToStr( Round( FileSize(file5000) * SizeOf(recTest)));

  CloseFile(file50);
  CloseFile(file500);
  CloseFile(file5000);

  rsProfiler[1].AsString;
  rsProfiler[2].AsString;
  rsProfiler[3].AsString;
end;

function SearchRecord(number: integer; choiceFile: integer): boolean;
var
  finded: boolean;
begin
  finded := false;
  NopP;
  rsProfiler.Clear;
  if (choiceFile = 50) then begin
    {$I-} Reset(file50); {$I+}
    if (IOResult <> 0) then begin
      ShowMessage('Файлът "File50.dat" не е намерен!');
      exit;
    end
    else begin
      rsProfiler[0].Start;

      while not EOF(file50) do begin
        Read(file50, recTest);
        if (recTest.number = number) then begin
          finded := true;
          break;
        end;
      end;

      rsProfiler[0].Stop;
      CloseFile(file50);
    end;
  end
  else if (choiceFile = 500) then begin
    {$I-} Reset(file500); {$I+}
    if (IOResult <> 0) then begin
      ShowMessage('Файлът "File500.dat" не е намерен!');
      exit;
    end
    else begin
      rsProfiler[0].Start;

      while not EOF(file500) do begin
        Read(file500, recTest);
        if (recTest.number = number) then begin
          finded := true;
          break;
        end;
      end;
      
      rsProfiler[0].Stop;
      CloseFile(file500);
    end;
  end
  else if (choiceFile = 5000) then begin
    {$I-} Reset(file5000); {$I+}
    if (IOResult <> 0) then begin
      ShowMessage('Файлът "File5000.dat" не е намерен!');
      exit;
    end
    else begin
      rsProfiler[0].Start;

      while not EOF(file5000) do begin
        Read(file5000, recTest);
        if (recTest.number = number) then begin
          finded := true;
          break;
        end;
      end;
      
      rsProfiler[0].Stop;
      CloseFile(file5000);
    end;
  end;
  rsProfiler[0].AsString;
  Result := finded;
end;


end.
 