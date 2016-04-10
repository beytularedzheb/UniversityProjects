program TestSequentialAccess;

uses
  Forms,
  SourceCodeMain in 'SourceCodeMain.pas' {frmMain},
  GenFiles in 'GenFiles.pas',
  UrsProfiler in 'UrsProfiler.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Testing - Sequence Access File';
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.
