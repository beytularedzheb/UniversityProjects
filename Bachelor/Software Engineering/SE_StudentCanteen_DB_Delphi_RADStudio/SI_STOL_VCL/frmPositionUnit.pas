unit frmPositionUnit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Error, FireDAC.UI.Intf, FireDAC.Phys.Intf, FireDAC.Stan.Def,
  FireDAC.Stan.Pool, FireDAC.Stan.Async, FireDAC.Phys, FireDAC.Phys.MSAcc,
  FireDAC.Phys.MSAccDef, FireDAC.Stan.Param, FireDAC.DatS, FireDAC.DApt.Intf,
  FireDAC.DApt, FireDAC.VCLUI.Wait, FireDAC.Comp.UI, Data.DB,
  FireDAC.Comp.DataSet, FireDAC.Comp.Client, Vcl.Grids, Vcl.DBGrids,
  Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.Buttons, gridOperUnit;

type
  TfrmPositions = class(TForm)
    grboxAdd: TGroupBox;
    btnAdd: TSpeedButton;
    btnClearAddForm: TSpeedButton;
    lbleditPosition: TLabeledEdit;
    grboxSearch: TGroupBox;
    btnSearch: TSpeedButton;
    btnDelete: TSpeedButton;
    lbleditSearch: TLabeledEdit;
    DBGrid1: TDBGrid;
    gboxEdit: TGroupBox;
    btnUpdate: TSpeedButton;
    btnClearEditPanel: TSpeedButton;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    FDQuery2: TFDQuery;
    DataSource1: TDataSource;
    FDGUIxWaitCursor1: TFDGUIxWaitCursor;
    lbleditEditPosition: TLabeledEdit;
    procedure btnClearAddFormClick(Sender: TObject);
    procedure btnClearEditPanelClick(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure btnUpdateClick(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure lbleditSearchKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmPositions: TfrmPositions;

implementation

{$R *.dfm}

procedure TfrmPositions.btnAddClick(Sender: TObject);
begin
  if string.IsNullOrEmpty(lbleditPosition.Text) then
    ShowMessage('���� �������� ��� �� ��������!')
  else begin
    FDQuery1.SQL.Text :=
      'INSERT INTO dlujnosti(dlujnost_ime) VALUES(:dlujnost_ime)';
    FDQuery1.ParamByName('dlujnost_ime').Value := lbleditPosition.Text;
    FDQuery1.ExecSQL;

    ShowMessage('���������� � ��������!');
    btnClearAddFormClick(Sender);
  end;
end;

procedure TfrmPositions.btnClearAddFormClick(Sender: TObject);
begin
  lbleditPosition.Clear;
end;

procedure TfrmPositions.btnClearEditPanelClick(Sender: TObject);
begin
  lbleditEditPosition.Clear;
end;

procedure TfrmPositions.btnDeleteClick(Sender: TObject);
var
  ID: string;
begin
  if MessageDlg('�������� �� ������ �� �� ������ �������?',
      mtCustom, [mbYes, mbNo], 0) = mrYes then begin
    ID := DBGrid1.DataSource.DataSet.FieldByName('dlujnost_id').AsString;
    FDQuery1.SQL.Text := 'DELETE FROM dlujnosti WHERE dlujnost_id = ' + ID;
    FDQuery1.ExecSQL;

    DBGrid1.DataSource.DataSet.Refresh;

    ShowMessage('��������� � ���������� ����� ' + ID + ' � ������!');
    btnClearEditPanelClick(Sender);
    gboxEdit.Visible := false;
    btnDelete.Visible := false;
  end;
end;

procedure TfrmPositions.btnSearchClick(Sender: TObject);
begin
  if not string.IsNullOrEmpty(lbleditSearch.Text) then begin
    FDQuery2.Active := false;
    FDQuery2.SQL.Text := 'SELECT * FROM dlujnosti WHERE dlujnost_Id=' +
        lbleditSearch.Text;
    FDQuery2.Active := true;
    if not DBGrid1.DataSource.DataSet.IsEmpty then begin
      SetGridColumnWidths(DBGrid1);
      gboxEdit.Visible := true;
      btnDelete.Visible := true;
    end
    else begin
      gboxEdit.Visible := false;
      btnDelete.Visible := false;
    end;
  end;
end;

procedure TfrmPositions.btnUpdateClick(Sender: TObject);
var
  queryStr: string;
begin
  if not string.IsNullOrEmpty(lbleditEditPosition.Text) then begin
    queryStr := 'UPDATE dlujnosti SET dlujnost_ime=' + QuotedStr(lbleditEditPosition.Text) +
       ' WHERE dlujnost_id=' + DBGrid1.DataSource.DataSet.FieldByName('dlujnost_id').AsString;

    FDQuery1.SQL.Clear;
    FDQuery1.ExecSQL(queryStr);
    btnClearEditPanelClick(Sender);

    DBGrid1.DataSource.DataSet.Refresh;
    SetGridColumnWidths(DBGrid1);
    ShowMessage('������� �� �����������!');
  end;
end;

procedure TfrmPositions.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  btnClearEditPanelClick(Sender);
  btnClearAddFormClick(Sender);
  btnDelete.Visible := false;
  gboxEdit.Visible := false;
  lbleditSearch.Clear;
  FDQuery2.Active := false; // clear dbgrid
end;

procedure TfrmPositions.lbleditSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    btnSearchClick(Sender);
end;

end.
