unit frmSearchUnit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.MSAcc,
  FireDAC.Phys.MSAccDef, FireDAC.VCLUI.Wait, FireDAC.Stan.Param, FireDAC.DatS,
  FireDAC.DApt.Intf, FireDAC.DApt, Data.DB, FireDAC.Comp.DataSet,
  FireDAC.Comp.Client, Vcl.Grids, Vcl.DBGrids, FireDAC.Comp.UI, Vcl.StdCtrls,
  Vcl.ExtCtrls, Vcl.Buttons, gridOperUnit;

type
  TfrmSearch = class(TForm)
    DataSource1: TDataSource;
    FDConnection1: TFDConnection;
    FDGUIxWaitCursor1: TFDGUIxWaitCursor;
    DBGrid1: TDBGrid;
    FDQuery1: TFDQuery;
    rbtnOrder: TRadioButton;
    gboxSearch: TGroupBox;
    rbtnDish: TRadioButton;
    rbtnStudent: TRadioButton;
    rbtnWorker: TRadioButton;
    rbtnPosition: TRadioButton;
    editSearch: TEdit;
    btnSearch: TSpeedButton;
    procedure rbtnOrderClick(Sender: TObject);
    procedure rbtnDishClick(Sender: TObject);
    procedure rbtnStudentClick(Sender: TObject);
    procedure rbtnWorkerClick(Sender: TObject);
    procedure rbtnPositionClick(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure editSearchKeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
var
  frmSearch: TfrmSearch;


implementation

{$R *.dfm}

procedure TfrmSearch.btnSearchClick(Sender: TObject);
begin
  if not string.IsNullOrEmpty(editSearch.Text) then begin
    FDQuery1.Active := false;

    if rbtnDish.Checked then begin
      try
        StrToInt(editSearch.Text);
        FDQuery1.SQL.Text := 'SELECT * FROM qstia WHERE qstia_id=' + editSearch.Text;
      except
        FDQuery1.SQL.Text := 'SELECT * FROM qstia WHERE ime LIKE ' +
        QuotedStr('%' + editSearch.Text + '%');
      end;
    end
    else if rbtnOrder.Checked then begin
      try
        StrToInt(editSearch.Text);
        FDQuery1.SQL.Text := 'SELECT * FROM orders WHERE fak_id=' + editSearch.Text;
      except
      end;
    end
    else if rbtnStudent.Checked then begin
      try
        StrToInt(editSearch.Text);
        FDQuery1.SQL.Text := 'SELECT * FROM studenti WHERE student_id=:txtstud';
        FDQuery1.ParamByName('txtstud').Value := editSearch.Text;
      except
        FDQuery1.SQL.Text := 'SELECT * FROM studenti WHERE ime LIKE ' +
        QuotedStr('%' + editSearch.Text + '%') + ' OR familia LIKE ' +
        QuotedStr('%' + editSearch.Text + '%');
      end;
    end
    else if rbtnWorker.Checked then begin
      try
        StrToInt(editSearch.Text);
        FDQuery1.SQL.Text := 'SELECT * FROM slujiteli WHERE slujitel_id=' + editSearch.Text;
      except
        FDQuery1.SQL.Text := 'SELECT * FROM slujiteli WHERE ime LIKE ' +
        QuotedStr('%' + editSearch.Text + '%') + ' OR familia LIKE ' +
        QuotedStr('%' + editSearch.Text + '%');
      end;
    end
    else if rbtnPosition.Checked then begin
      try
        StrToInt(editSearch.Text);
        FDQuery1.SQL.Text := 'SELECT * FROM dlujnosti WHERE dlujnost_id=' + editSearch.Text;
      except
        FDQuery1.SQL.Text := 'SELECT * FROM dlujnosti WHERE dlujnost_ime LIKE ' +
        QuotedStr('%' + editSearch.Text + '%');
      end;
    end;

    FDQuery1.Active := true;
    SetGridColumnWidths(DBGrid1);
  end;
end;

procedure TfrmSearch.editSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    btnSearchClick(Sender);
end;

procedure TfrmSearch.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  rbtnOrder.Checked := true;
  editSearch.Clear;
end;

procedure TfrmSearch.FormShow(Sender: TObject);
begin
  rbtnOrderClick(Sender);
  editSearch.Clear;
end;

procedure TfrmSearch.rbtnDishClick(Sender: TObject);
begin
  FDQuery1.Active := false;
  FDQuery1.SQL.Text := 'SELECT * FROM qstia';
  FDQuery1.Active := true;
  SetGridColumnWidths(DBGrid1);
end;

procedure TfrmSearch.rbtnOrderClick(Sender: TObject);
begin
  FDQuery1.Active := false;
  FDQuery1.SQL.Text := 'SELECT * FROM orders';
  FDQuery1.Active := true;
  SetGridColumnWidths(DBGrid1);
end;

procedure TfrmSearch.rbtnPositionClick(Sender: TObject);
begin
  FDQuery1.Active := false;
  FDQuery1.SQL.Text := 'SELECT * FROM dlujnosti';
  FDQuery1.Active := true;
  SetGridColumnWidths(DBGrid1);
end;

procedure TfrmSearch.rbtnStudentClick(Sender: TObject);
begin
  FDQuery1.Active := false;
  FDQuery1.SQL.Text := 'SELECT * FROM studenti';
  FDQuery1.Active := true;
  SetGridColumnWidths(DBGrid1);
end;

procedure TfrmSearch.rbtnWorkerClick(Sender: TObject);
begin
  FDQuery1.Active := false;
  FDQuery1.SQL.Text := 'SELECT * FROM slujiteli';
  FDQuery1.Active := true;
  SetGridColumnWidths(DBGrid1);
end;

end.
