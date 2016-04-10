unit frmStudentUnit;

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
  TfrmStudents = class(TForm)
    grboxAdd: TGroupBox;
    btnAdd: TSpeedButton;
    btnClearAddForm: TSpeedButton;
    lbleditStudFacNumb: TLabeledEdit;
    lbleditFirstName: TLabeledEdit;
    lbleditFamName: TLabeledEdit;
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
    lbleditEditAddress: TLabeledEdit;
    FDConnection1: TFDConnection;
    FDQuery1: TFDQuery;
    FDQuery2: TFDQuery;
    DataSource1: TDataSource;
    FDGUIxWaitCursor1: TFDGUIxWaitCursor;
    lbleditAddress: TLabeledEdit;
    lbleditPhoneNum: TLabeledEdit;
    lbleditEditPhoneNum: TLabeledEdit;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure btnClearAddFormClick(Sender: TObject);
    procedure btnClearEditPanelClick(Sender: TObject);
    procedure btnAddClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure btnUpdateClick(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure lbleditSearchKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmStudents: TfrmStudents;

implementation

{$R *.dfm}

procedure TfrmStudents.btnAddClick(Sender: TObject);
begin
  if string.IsNullOrEmpty(lbleditStudFacNumb.Text) then
    ShowMessage('���� �������� ���������� �����!')
  else if string.IsNullOrEmpty(lbleditFirstName.Text) then
    ShowMessage('���� �������� ���!')
  else if string.IsNullOrEmpty(lbleditFamName.Text) then
    ShowMessage('���� �������� ������� ���!')
  else if string.IsNullOrEmpty(lbleditAddress.Text) then
    ShowMessage('���� �������� �����!')
  else if string.IsNullOrEmpty(lbleditPhoneNum.Text) then
    ShowMessage('���� �������� ��������� �����!')
  else begin
    FDQuery1.SQL.Text :=
      'INSERT INTO Studenti(student_id, ime, familia, adres, telefon) ' +
      'VALUES(:student_id, :ime, :familia, :adres, :telefon)';
    FDQuery1.ParamByName('student_id').Value := lbleditStudFacNumb.Text;
    FDQuery1.ParamByName('ime').Value := lbleditFirstName.Text;
    FDQuery1.ParamByName('familia').Value := lbleditFamName.Text;
    FDQuery1.ParamByName('adres').Value := lbleditAddress.Text;
    FDQuery1.ParamByName('telefon').Value := lbleditPhoneNum.Text;
    FDQuery1.ExecSQL;

    ShowMessage('��������� � �������!');
    btnClearAddFormClick(Sender);
  end;
end;

procedure TfrmStudents.btnClearAddFormClick(Sender: TObject);
begin
  lbleditStudFacNumb.Clear;
  lbleditFirstName.Clear;
  lbleditAddress.Clear;
  lbleditPhoneNum.Clear;
  lbleditFamName.Clear;
end;

procedure TfrmStudents.btnClearEditPanelClick(Sender: TObject);
begin
  lbleditEditFirstName.Clear;
  lbleditEditFamName.Clear;
  lbleditEditAddress.Clear;
  lbleditEditPhoneNum.Clear;
end;

procedure TfrmStudents.btnDeleteClick(Sender: TObject);
var
  ID: string;
begin
  if MessageDlg('�������� �� ������ �� �� ������ �������?',
      mtCustom, [mbYes, mbNo], 0) = mrYes then begin
    ID := DBGrid1.DataSource.DataSet.FieldByName('student_id').AsString;
    FDQuery1.SQL.Text := 'DELETE FROM studenti WHERE student_id = ' + QuotedStr(ID);
    FDQuery1.ExecSQL;

    DBGrid1.DataSource.DataSet.Refresh;

    ShowMessage('��������� � ���������� ����� ' + ID + ' � ������!');
    btnClearEditPanelClick(Sender);
    gboxEdit.Visible := false;
    btnDelete.Visible := false;
  end;
end;

procedure TfrmStudents.btnSearchClick(Sender: TObject);
begin
  if not string.IsNullOrEmpty(lbleditSearch.Text) then begin
    FDQuery2.Active := false;
    FDQuery2.SQL.Text := 'SELECT * FROM studenti WHERE student_Id=' +
        QuotedStr(lbleditSearch.Text);
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

procedure TfrmStudents.btnUpdateClick(Sender: TObject);
var
  queryStr: string;
  tr: boolean;
begin
  tr := false;
  queryStr := 'UPDATE studenti SET ';
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
  if not string.IsNullOrEmpty(lbleditEditAddress.Text) then begin
    if tr then
      queryStr := queryStr +  ', adres=' + QuotedStr(lbleditEditAddress.Text)
    else
      queryStr := queryStr +  'adres=' + QuotedStr(lbleditEditAddress.Text);
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
  if tr then begin
    queryStr := queryStr + ' WHERE student_id=' +
      QuotedStr(DBGrid1.DataSource.DataSet.FieldByName('student_id').AsString);

    FDQuery1.SQL.Clear;
    FDQuery1.ExecSQL(queryStr);

    btnClearEditPanelClick(Sender);

    DBGrid1.DataSource.DataSet.Refresh;
    SetGridColumnWidths(DBGrid1);
    ShowMessage('������� �� �����������!');
  end;
//-------------------------------------------------------------------------------------
end;

procedure TfrmStudents.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  btnClearEditPanelClick(Sender);
  btnClearAddFormClick(Sender);
  btnDelete.Visible := false;
  gboxEdit.Visible := false;
  lbleditSearch.Clear;
  FDQuery2.Active := false; // clear dbgrid
end;

procedure TfrmStudents.lbleditSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    btnSearchClick(Sender);
end;

end.
