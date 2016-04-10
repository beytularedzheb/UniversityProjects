unit frmWorkerUnit;

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
  TfrmWorkers = class(TForm)
    grboxAdd: TGroupBox;
    btnAdd: TSpeedButton;
    btnClearAddForm: TSpeedButton;
    lbleditFirstName: TLabeledEdit;
    lbleditFamName: TLabeledEdit;
    lbleditSalary: TLabeledEdit;
    lbleditPhoneNum: TLabeledEdit;
    grboxSearch: TGroupBox;
    btnSearch: TSpeedButton;
    btnDelete: TSpeedButton;
    lbleditSearch: TLabeledEdit;
    DBGrid1: TDBGrid;
    gboxEdit: TGroupBox;
    btnUpdate: TSpeedButton;
    btnClearEditPanel: TSpeedButton;
    lbleditEditFirstName: TLabeledEdit;
    lbleditEditFamName: TLabeledEdit;
    lbleditEditSalary: TLabeledEdit;
    lbleditEditPhoneNum: TLabeledEdit;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    FDQuery2: TFDQuery;
    DataSource1: TDataSource;
    FDGUIxWaitCursor1: TFDGUIxWaitCursor;
    cboxPosition: TComboBox;
    lblPosition: TLabel;
    cboxEditPosition: TComboBox;
    lblEditPosition: TLabel;
    procedure btnClearAddFormClick(Sender: TObject);
    procedure btnClearEditPanelClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure btnUpdateClick(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure lbleditSearchKeyPress(Sender: TObject; var Key: Char);
    procedure lbleditEditSalaryKeyPress(Sender: TObject; var Key: Char);
    procedure lbleditSalaryKeyPress(Sender: TObject; var Key: Char);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmWorkers: TfrmWorkers;

implementation

{$R *.dfm}

procedure TfrmWorkers.btnAddClick(Sender: TObject);
begin
  if string.IsNullOrEmpty(lbleditFirstName.Text) then
    ShowMessage('Моля въведете име!')
  else if string.IsNullOrEmpty(lbleditFamName.Text) then
    ShowMessage('Моля въведете фамилно име!')
  else if string.IsNullOrEmpty(lbleditSalary.Text) then
    ShowMessage('Моля въведете заплата!')
  else if string.IsNullOrEmpty(lbleditPhoneNum.Text) then
    ShowMessage('Моля въведете телефонен номер!')
  else if cboxPosition.ItemIndex = -1 then begin
    ShowMessage('Моля изберете длъжност!');
  end
  else begin
    FDQuery1.SQL.Text :=
      'INSERT INTO slujiteli(ime, familia, zaplata, telefon, dlujnost_id) ' +
      'VALUES(:ime, :familia, :zaplata, :telefon,:dlujnost_id)';
    FDQuery1.ParamByName('ime').Value := lbleditFirstName.Text;
    FDQuery1.ParamByName('familia').Value := lbleditFamName.Text;
    FDQuery1.ParamByName('zaplata').Value := StrToFloat(lbleditSalary.Text);
    FDQuery1.ParamByName('telefon').Value := lbleditPhoneNum.Text;
    FDQuery1.ParamByName('dlujnost_id').Value := cboxPosition.Items[cboxPosition.ItemIndex].Split(['|'])[1];
    FDQuery1.ExecSQL;

    ShowMessage('Служителят е добавен!');
    btnClearAddFormClick(Sender);
  end;
end;

procedure TfrmWorkers.btnClearAddFormClick(Sender: TObject);
begin
  lbleditFirstName.Clear;
  lbleditSalary.Clear;
  lbleditPhoneNum.Clear;
  lbleditFamName.Clear;
  cboxPosition.ItemIndex := -1;
end;

procedure TfrmWorkers.btnClearEditPanelClick(Sender: TObject);
begin
  lbleditEditFirstName.Clear;
  lbleditEditFamName.Clear;
  lbleditEditSalary.Clear;
  lbleditEditPhoneNum.Clear;
  cboxEditPosition.ItemIndex := -1;
end;

procedure TfrmWorkers.btnDeleteClick(Sender: TObject);
var
  ID: string;
begin
  if MessageDlg('Наистина ли искате да се изтрие записът?',
      mtCustom, [mbYes, mbNo], 0) = mrYes then begin
    ID := DBGrid1.DataSource.DataSet.FieldByName('slujitel_id').AsString;
    FDQuery1.SQL.Text := 'DELETE FROM slujiteli WHERE slujitel_id = ' + ID;
    FDQuery1.ExecSQL;

    DBGrid1.DataSource.DataSet.Refresh;

    ShowMessage('Служителят с номер ' + ID + ' е изтрит!');
    btnClearEditPanelClick(Sender);
    gboxEdit.Visible := false;
    btnDelete.Visible := false;
  end;
end;

procedure TfrmWorkers.btnSearchClick(Sender: TObject);
begin
  if not string.IsNullOrEmpty(lbleditSearch.Text) then begin
    FDQuery2.Active := false;
    FDQuery2.SQL.Text := 'SELECT * FROM slujiteli WHERE slujitel_Id=' + lbleditSearch.Text;
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

procedure TfrmWorkers.btnUpdateClick(Sender: TObject);
var
  queryStr: string;
  tr: boolean;
begin
  tr := false;
  queryStr := 'UPDATE slujiteli SET ';
//-------------------------------------------------------------------------------------
  if not string.IsNullOrEmpty(lbleditEditFirstName.Text) then begin
    queryStr := queryStr + 'ime=' + QuotedStr(lbleditEditFirstName.Text);
    tr := true;
  end;
//-------------------------------------------------------------------------------------
  if not string.IsNullOrEmpty(lbleditEditFamName.Text) then begin
    if tr then
       queryStr := queryStr + ', familia=' + QuotedStr(lbleditEditFamName.Text)
    else begin
      queryStr := queryStr + 'familia=' + QuotedStr(lbleditEditFamName.Text);
    end;
    tr := true;
  end;
//-------------------------------------------------------------------------------------
  if not string.IsNullOrEmpty(lbleditEditSalary.Text) then begin
    if tr then
      queryStr := queryStr +  ', adres=' + lbleditEditSalary.Text
    else
      queryStr := queryStr +  'adres=' + lbleditEditSalary.Text;
        tr := true;
  end;
//-------------------------------------------------------------------------------------
  if not string.IsNullOrEmpty(lbleditEditPhoneNum.Text) then begin
    if tr then
      queryStr := queryStr +  ', telefon=' + QuotedStr(lbleditEditPhoneNum.Text)
    else
      queryStr := queryStr +  'telefon=' + QuotedStr(lbleditEditPhoneNum.Text);
        tr := true;
  end;
//-------------------------------------------------------------------------------------
  if cboxEditPosition.ItemIndex > -1 then begin
    if tr then
      queryStr := queryStr +  ', dlujnost_id=' +
        cboxEditPosition.Items[cboxEditPosition.ItemIndex].Split(['|'])[1]
    else
      queryStr := queryStr +  'dlujnost_id=' +
        cboxEditPosition.Items[cboxEditPosition.ItemIndex].Split(['|'])[1];
        tr := true;
  end;
//-------------------------------------------------------------------------------------
  if tr then begin
    queryStr := queryStr + ' WHERE slujitel_id=' +
      DBGrid1.DataSource.DataSet.FieldByName('slujitel_id').AsString;

    FDQuery1.SQL.Clear;
    FDQuery1.ExecSQL(queryStr);

    btnClearEditPanelClick(Sender);

    DBGrid1.DataSource.DataSet.Refresh;
    SetGridColumnWidths(DBGrid1);
    ShowMessage('Данните са редактирани!');
  end;
//-------------------------------------------------------------------------------------
end;

procedure TfrmWorkers.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  btnClearEditPanelClick(Sender);
  btnClearAddFormClick(Sender);
  btnDelete.Visible := false;
  gboxEdit.Visible := false;
  lbleditSearch.Clear;
  FDQuery2.Active := false; // clear dbgrid
end;

procedure TfrmWorkers.FormShow(Sender: TObject);
var
  posStr: string;
begin
  cboxPosition.Clear;
  cboxEditPosition.Clear;

  FDQuery1.Open('SELECT dlujnost_ime, dlujnost_id FROM dlujnosti');
  while not FDQuery1.Eof do begin
    posStr := FDQuery1.FieldByName('dlujnost_ime').AsString +
        '|' + FDQuery1.FieldByName('dlujnost_id').AsString;
    cboxPosition.Items.Add(posStr);
    cboxEditPosition.Items.Add(posStr);
    FDQuery1.Next;
  end;
  FDQuery1.Close;
end;

procedure TfrmWorkers.lbleditEditSalaryKeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9', '.', #8] = false then
    Key := #0;
end;

procedure TfrmWorkers.lbleditSalaryKeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9', '.', #8] = false then
    Key := #0;
end;

procedure TfrmWorkers.lbleditSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    btnSearchClick(Sender);
end;

end.
