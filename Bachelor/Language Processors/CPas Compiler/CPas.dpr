program CPas;

uses
  Forms,
  Windows,
  SourceCode in 'SourceCode.pas' {formMain},
  SyntacticAnalysis in 'SyntacticAnalysis.pas',
  SemanticAnalysis in 'SemanticAnalysis.pas',
  GenerateObjectCode in 'GenerateObjectCode.pas',
  SourceCodeAbout in 'SourceCodeAbout.pas' {formAbout};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'C-Pas 1.0';
  Application.HintColor := RGB(250, 235, 100);
  Application.CreateForm(TformMain, formMain);
  Application.CreateForm(TformAbout, formAbout);
  Application.Run;
end.
