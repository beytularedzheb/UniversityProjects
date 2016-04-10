program Konvertor;

uses
  Forms,
  KMain in 'KMain.pas' {frmMain},
  About in 'About.pas' {frmAbout};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Converter';
  Application.CreateForm(TfrmMain, frmMain);
  Application.CreateForm(TfrmAbout, frmAbout);
  Application.Run;
end.
