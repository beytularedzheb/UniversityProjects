unit frmOrdersUnit;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.DBCtrls, Vcl.ExtCtrls,
  Vcl.Buttons, Vcl.Grids, Vcl.DBGrids, Vcl.ComCtrls, FireDAC.Stan.Intf,
  FireDAC.Stan.Option, FireDAC.Stan.Param, FireDAC.Stan.Error, FireDAC.DatS,
  FireDAC.Phys.Intf, FireDAC.DApt.Intf, FireDAC.Stan.Async, FireDAC.DApt,
  Data.DB, FireDAC.Comp.DataSet, FireDAC.Comp.Client, FireDAC.UI.Intf,
  FireDAC.Stan.Def, FireDAC.Stan.Pool, FireDAC.Phys, FireDAC.Phys.MSAcc,
  FireDAC.Phys.MSAccDef, FireDAC.VCLUI.Wait, FireDAC.Comp.UI, Data.Win.ADODB, gridOperUnit;

type
  TfrmOrders = class(TForm)
    lbleditStudID: TLabeledEdit;
    btnAddOrder: TSpeedButton;
    btnClearOrderForm: TSpeedButton;
    lblDish: TLabel;
    grboxAdd: TGroupBox;
    btnSearch: TSpeedButton;
    grboxSearch: TGroupBox;
    lbleditSearch: TLabeledEdit;
    gboxEdit: TGroupBox;
    btnUpdateOrder: TSpeedButton;
    cboxStudent: TComboBox;
    cboxEditDish: TComboBox;
    lblWorker: TLabel;
    lblCboxDish: TLabel;
    lblStudent: TLabel;
    cboxDishes: TComboBox;
    FDQuery1: TFDQuery;
    FDConnection1: TFDConnection;
    FDGUIxWaitCursor1: TFDGUIxWaitCursor;
    cboxWorker: TComboBox;
    DBGrid1: TDBGrid;
    FDQuery2: TFDQuery;
    DataSource1: TDataSource;
    btnDeleteOrder: TSpeedButton;
    btnClearEditPanel: TSpeedButton;
    procedure FormShow(Sender: TObject);
    procedure btnSearchClick(Sender: TObject);
    procedure btnDeleteOrderClick(Sender: TObject);
    procedure btnClearOrderFormClick(Sender: TObject);
    procedure btnUpdateOrderClick(Sender: TObject);
    procedure btnClearEditPanelClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure lbleditSearchKeyPress(Sender: TObject; var Key: Char);
    procedure btnAddOrderClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    workerID: string;
  end;

var
  frmOrders: TfrmOrders;

implementation

{$R *.dfm}

procedure TfrmOrders.btnAddOrderClick(Sender: TObject);
var
  checkStudent: boolean;
  qstieID: integer;
begin
  if not string.IsNullOrEmpty(lbleditStudID.Text) then begin
    FDQuery1.Open('SELECT * FROM Studenti where Student_id=' + QuotedStr(lbleditStudID.Text));
    checkStudent := not FDQuery1.Eof;
    FDQuery1.Close;
  end;
  if string.IsNullOrEmpty(lbleditStudID.Text) then
    ShowMessage('���� �������� ���������� �����!')
  else if not checkStudent then
    ShowMessage('������ ��� ������������ ���������� �����!')
  else if cboxDishes.ItemIndex = -1 then
    ShowMessage('���� �������� ����� �� ������!')
  else begin
    FDQuery1.SQL.Text := 'SELECT Qstia_id FROM Qstia where Qstia_id=:selectedItem';
    FDQuery1.ParamByName('selectedItem').Value := cboxDishes.Items[cboxDishes.ItemIndex].Split(['|'])[1];
    FDQuery1.Open();
    qstieID := FDQuery1.FieldByName('QSTIA_ID').AsInteger;
    FDQuery1.Close;

    FDQuery1.SQL.Text :=
      'INSERT INTO Orders(slujitel_id, qstia_id, student_id, data_poruchki)' +
      ' values(:slujitel_id, :qstia_id, :student_id, :data_poruchki)';
    FDQuery1.ParamByName('slujitel_id').Value := StrToInt(workerID);
    FDQuery1.ParamByName('qstia_id').Value := qstieID;
    FDQuery1.ParamByName('student_id').Value := QuotedStr(lbleditStudID.Text);
    FDQuery1.ParamByName('data_poruchki').Value := Now;//FormatDateTime('dd.mm.yyyy hh:nn:ss.zzz', Now);
    FDQuery1.ExecSQL;

    ShowMessage('��������� � �������� �������!');
    btnClearOrderFormClick(Sender);
  end;
end;

procedure TfrmOrders.btnClearEditPanelClick(Sender: TObject);
begin
  cboxWorker.ItemIndex := -1;
  cboxEditDish.ItemIndex := -1;
  cboxStudent.ItemIndex := -1;
end;

procedure TfrmOrders.btnClearOrderFormClick(Sender: TObject);
begin
  lbleditStudID.Clear;
  cboxDishes.ItemIndex := -1;
end;

procedure TfrmOrders.btnDeleteOrderClick(Sender: TObject);
var
  poruchkaNomer: string;
begin
  if MessageDlg('�������� �� ������ �� �� ������ �������?',
      mtCustom, [mbYes, mbNo], 0) = mrYes then begin
    FDQuery1.Open;
    poruchkaNomer := DBGrid1.DataSource.DataSet.FieldByName('FAK_ID').AsString;
    FDQuery1.SQL.Text := 'Delete from Orders where Fak_Id=' + poruchkaNomer;
    FDQuery1.ExecSQL;
    FDQuery1.Close;
    DBGrid1.DataSource.DataSet.Refresh;

    ShowMessage('������� ����� ' + poruchkaNomer + ' � �������!');
    btnClearEditPanelClick(Sender);
    gboxEdit.Visible := false;
    btnDeleteOrder.Visible := false;
  end;
end;

procedure TfrmOrders.btnSearchClick(Sender: TObject);
begin
  if not string.IsNullOrEmpty(lbleditSearch.Text) then begin
    FDQuery2.Active := false;
    FDQuery2.SQL.Text := 'Select * from Orders where Fak_Id='+lbleditSearch.Text;
    FDQuery2.Active := true;
    if not DBGrid1.DataSource.DataSet.IsEmpty then begin
      SetGridColumnWidths(DBGrid1);
      gboxEdit.Visible := true;
      btnDeleteOrder.Visible := true;
    end
    else begin
      gboxEdit.Visible := false;
      btnDeleteOrder.Visible := false;
    end;
  end;
end;

procedure TfrmOrders.btnUpdateOrderClick(Sender: TObject);
var
  queryStr: string;
  tr: boolean;
begin
  tr := false;
  queryStr := 'UPDATE Orders SET ';
//-------------------------------------------------------------------------------------
  if cboxWorker.ItemIndex > -1 then begin
    queryStr := queryStr + 'slujitel_id=' + cboxWorker.Items[cboxWorker.ItemIndex];
    tr := true;
  end;
//-------------------------------------------------------------------------------------
  if cboxEditDish.ItemIndex > -1 then begin
    if tr then
       queryStr := queryStr + ', qstia_id=' + cboxEditDish.Items[cboxEditDish.ItemIndex].Split(['|'])[1]
    else begin
      queryStr := queryStr + 'qstia_id=' + cboxEditDish.Items[cboxEditDish.ItemIndex].Split(['|'])[1];
    end;
    tr := true;
  end;
//-------------------------------------------------------------------------------------
  if cboxStudent.ItemIndex > -1 then begin
    if tr then
      queryStr := queryStr +  ', student_id=' + cboxStudent.Items[cboxStudent.ItemIndex]
    else
      queryStr := queryStr +  'student_id=' + cboxStudent.Items[cboxStudent.ItemIndex];
        tr := true;
  end;
//-------------------------------------------------------------------------------------
  if tr then begin
    queryStr := queryStr + ' WHERE fak_id=' +
      DBGrid1.DataSource.DataSet.FieldByName('fak_id').AsString;
    FDQuery1.ExecSQL(queryStr);

    btnClearEditPanelClick(Sender);

    DBGrid1.DataSource.DataSet.Refresh;
    SetGridColumnWidths(DBGrid1);
    ShowMessage('������� �� �����������!');
  end;
//-------------------------------------------------------------------------------------
end;

procedure TfrmOrders.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  btnClearEditPanelClick(Sender);
  btnClearOrderFormClick(Sender);
  btnDeleteOrder.Visible := false;
  gboxEdit.Visible := false;
  lbleditSearch.Clear;
  FDQuery2.Active := false; // clear dbgrid
end;

procedure TfrmOrders.FormShow(Sender: TObject);
var
  dishStr: string;
begin
  cboxDishes.Clear;
  cboxEditDish.Clear;

  FDQuery1.Open('SELECT ime, qstia_id FROM Qstia');
  while not FDQuery1.Eof do begin
    dishStr := FDQuery1.FieldByName('ime').AsString +
        '|' + FDQuery1.FieldByName('qstia_id').AsString;
    cboxDishes.Items.Add(dishStr);
    cboxEditDish.Items.Add(dishStr);
    FDQuery1.Next;
  end;
  FDQuery1.Close;

  cboxWorker.Clear;
  FDQuery1.SQL.Clear;
  FDQuery1.Open('SELECT Slujitel_ID FROM Slujiteli');
  while not FDQuery1.Eof do begin
    cboxWorker.Items.Add(FDQuery1.FieldByName('Slujitel_ID').AsString);
    FDQuery1.Next;
  end;
  FDQuery1.Close;

  cboxStudent.Clear;
  FDQuery1.SQL.Clear;
  FDQuery1.Open('SELECT Student_ID FROM Studenti');
  while not FDQuery1.Eof do begin
    cboxStudent.Items.Add(FDQuery1.FieldByName('Student_ID').AsString);
    FDQuery1.Next;
  end;
  FDQuery1.Close;
end;

procedure TfrmOrders.lbleditSearchKeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    btnSearchClick(Sender);
end;

end.
