program StudentskiStol;

uses
  Vcl.Forms,
  frmMainUnit in 'frmMainUnit.pas' {frmMain},
  frmOrdersUnit in 'frmOrdersUnit.pas' {frmOrders},
  frmSearchUnit in 'frmSearchUnit.pas' {frmSearch},
  frmMenuUnit in 'frmMenuUnit.pas' {frmMenu},
  frmStudentUnit in 'frmStudentUnit.pas' {frmStudents},
  gridOperUnit in 'gridOperUnit.pas',
  frmWorkerUnit in 'frmWorkerUnit.pas' {frmWorkers}

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmMain, frmMain);
  Application.CreateForm(TfrmOrders, frmOrders);
  Application.CreateForm(TfrmSearch, frmSearch);
  Application.CreateForm(TfrmMenu, frmMenu);
  Application.CreateForm(TfrmStudents, frmStudents);
  Application.CreateForm(TfrmWorkers, frmWorkers);
  Application.Run;
end.
