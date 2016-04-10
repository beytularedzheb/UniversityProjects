program GraphicalEditor;

uses
  Forms,
  SourceCodeMain in 'SourceCodeMain.pas' {formMain},
  SourceCodeAbout in 'SourceCodeAbout.pas' {formAbout},
  VectorFileSC in 'VectorFileSC.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Graphical Editor Of Logical Elements';
  Application.CreateForm(TformMain, formMain);
  Application.CreateForm(TformAbout, formAbout);
  Application.Run;
end.
