unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Grids, Unit3;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Panel1: TPanel;
    LabeledEdit1: TLabeledEdit;
    LabeledEdit2: TLabeledEdit;
    LabeledEdit3: TLabeledEdit;
    LabeledEdit4: TLabeledEdit;
    LabeledEdit5: TLabeledEdit;
    LabeledEdit6: TLabeledEdit;
    LabeledEdit7: TLabeledEdit;
    StringGrid1: TStringGrid;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure LabeledEdit1KeyPress(Sender: TObject; var Key: Char);
    procedure LabeledEdit7KeyPress(Sender: TObject; var Key: Char);
    procedure FormCreate(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);

  private
    { Private declarations }
    start_seans: string;
    end_seans: string;
  public
    { Public declarations }
    procedure Search(input: string);
  end;

var
  Form1: TForm1;

implementation

uses Unit2;

{$R *.dfm}

{ ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss }

procedure TForm1.Search(input: string);
var
  curDiplomna: TDiplomnaRabota;
  found_count: integer;
begin
  found_count := 0;

  {$I-}
  Reset(infF);
  {$I+}
  if IOResult = 0 then begin
    while not Eof(infF) do begin
      Read(infF, curDiplomna);
      if ((LowerCase(input) = 'n_' + curDiplomna.por_nom) and
      (curDiplomna.zaet = 0)) or (input = curDiplomna.fac_nom) then begin
        Panel1.Visible := true;
        StringGrid1.Visible := false;

        LabeledEdit1.Text := curDiplomna.por_nom;
        LabeledEdit2.Text := curDiplomna.tema_ime;
        LabeledEdit3.Text := curDiplomna.ezik_za_progr;
        LabeledEdit4.Text := curDiplomna.tip_pril;
        LabeledEdit5.Text := curDiplomna.rukovoditel;
        LabeledEdit6.Text := curDiplomna.student;
        LabeledEdit7.Text := curDiplomna.fac_nom;
        break;
      end
      else if ((LowerCase(input) = 'nezaeti') and (curDiplomna.zaet = 0)) or
      ((LowerCase(input) = 'zaeti') and (curDiplomna.zaet = 1)) or
      (LowerCase(input) = LowerCase(curDiplomna.rukovoditel)) then begin
        Panel1.Visible := false;
        StringGrid1.Visible := true;

        Inc(found_count);
        StringGrid1.Cells[0, found_count] := curDiplomna.por_nom;
        StringGrid1.Cells[1, found_count] := curDiplomna.tema_ime;
        StringGrid1.Cells[2, found_count] := curDiplomna.ezik_za_progr;
        StringGrid1.Cells[3, found_count] := curDiplomna.tip_pril;
        StringGrid1.Cells[4, found_count] := curDiplomna.rukovoditel;
        StringGrid1.Cells[5, found_count] := curDiplomna.student;
        StringGrid1.Cells[6, found_count] := curDiplomna.fac_nom;
        StringGrid1.RowCount := found_count + 1;
      end
      else begin
        if (found_count = 0) then begin
          Panel1.Visible := false;
          StringGrid1.Visible := false;
        end;
      end;
    end;
    CloseFile(infF);
  end
  else begin
    ShowMessage('Файлът не е намерен');
  end;
end;

{ ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss }

procedure TForm1.Button1Click(Sender: TObject);
begin
  if (fileName <> '') then begin
    if (Edit1.Text <> '') then begin
      Search(Edit1.Text);
      tyrsene := '+';
    end
    else begin
      Panel1.Visible := false;
      StringGrid1.Visible := false;
    end;
  end
  else begin
    ShowMessage('Не сте избрали файл за четене!');
  end;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  Form1.Close;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  // TODO: open new frame - add
  if (fileName <> '') then begin
    Form2.Show;
  end
  else begin
    ShowMessage('Не сте избрали файл!');
  end;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  diplomna: TDiplomnaRabota;
  n: integer;
begin
  // TODO: edit data
  if (LabeledEdit2.Text = '') then begin
    ShowMessage('Моля въведете наименованието на темата!');
  end
  else if (LabeledEdit3.Text = '') then begin
    ShowMessage('Моля въведете езика за програмиране!');
  end
  else if (LabeledEdit4.Text = '') then begin
    ShowMessage('Моля въведете типа на приложението!');
  end
  else if (LabeledEdit5.Text = '') then begin
    ShowMessage('Моля въведете научният ръководител!');
  end
  else if (LabeledEdit6.Text = '') then begin
    ShowMessage('Моля въведете 3-те имена на студента!');
  end
  else if (Length(LabeledEdit7.Text) <> 6) then begin
    ShowMessage('Невалиден факултетен номер!');
  end
  else begin
      {$I-}
      Reset(infF);
      {$I+}
      if (IOResult = 0) then begin
        while not EOF(infF) do begin
          Read(infF, diplomna);
          if (LabeledEdit1.Text = diplomna.por_nom) and
          (MessageDlg('Редактиране?',
            mtConfirmation, [mbYes, mbNo], 0) = mrYes) then begin
            n := FilePos(infF) - 1;
            diplomna.por_nom := Form1.LabeledEdit1.Text;
            diplomna.tema_ime := Form1.LabeledEdit2.Text;
            diplomna.ezik_za_progr := Form1.LabeledEdit3.Text;
            diplomna.tip_pril := Form1.LabeledEdit4.Text;
            diplomna.rukovoditel := Form1.LabeledEdit5.Text;
            diplomna.student := Form1.LabeledEdit6.Text;
            diplomna.fac_nom := Form1.LabeledEdit7.Text;
            diplomna.zaet := 1;
            Seek(infF, n);
            Write(infF, diplomna);
            redaktirane := '+';
            ShowMessage('Данните са редактирани!');
            break;
          end;
        end;
        CloseFile(infF);
      end
      else begin
        ShowMessage('Файлът не е намерен');
      end;
  end;
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  DelFl: InfFile;
  curDip: TDiplomnaRabota;
begin
  {$I-}
  Reset(infF);
  {$I+}
  if (IOResult = 0) then begin
    AssignFile(DelFl, 'Del');
    Rewrite(DelFl);
    while not EOF(infF) do begin
      Read(infF, curDip);
      if (LabeledEdit1.Text <> curDip.por_nom) then begin
        Write(DelFl, curDip);
      end
      else begin
        ShowMessage('Данните са изтрити!');
        iztrivane := '+';
        Panel1.Visible := false;
      end;
    end;
    CloseFile(infF); CloseFile(DelFl);
    Erase(infF); Rename(DelFl, fileName);
  end
  else begin
    ShowMessage('Файлът не е намерен');
  end;
end;

procedure TForm1.LabeledEdit1KeyPress(Sender: TObject; var Key: Char);
begin
  if (Key in ['0'..'9', #8] = false) then begin
    Key := #0;
  end;
end;

procedure TForm1.LabeledEdit7KeyPress(Sender: TObject; var Key: Char);
begin
  if (Key in ['0'..'9', #8] = false) then begin
    Key := #0;
  end;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  // TODO: create new file
  if (SaveDialog1.Execute) then begin
    fileName := SaveDialog1.FileName;
    if (Pos('.diploma', fileName) = 0) then begin
      fileName := fileName + '.diploma';
    end;
    Form1.Caption := fileName;
    AssignFile(infF, fileName);
    Rewrite(infF);
    CloseFile(infF);
    syzd_fail := '+';
  end;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  // TODO: open file
  if (OpenDialog1.Execute) then begin
    fileName := OpenDialog1.FileName;
    Form1.Caption := fileName;
    AssignFile(infF, fileName);
    otvarqne := '+';
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  fileName := '';
  tyrsene := '-';
  redaktirane := '-';
  syzd_fail := '-';
  otvarqne := '-';
  dobavqne := '-';
  iztrivane := '-';
  start_seans := DateToStr(Now);
  start_seans := start_seans + ' ' + TimeToStr(Now);
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if (Key = #13) then begin
    Button1Click(Sender);
  end;
end;

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  end_seans := DateToStr(Now);
  end_seans := end_seans + ' ' + TimeToStr(Now);
  ShowMessage('Начало: ' + start_seans + #10#13 + 'Край: ' + end_seans +
    #10#13 + 'Търсене: ' + tyrsene + #10#13 + 'Редактиране: ' +
    redaktirane + #10#13 + 'Създаване на файл: ' + syzd_fail + #10#13 +
    'Отваряне на файл: ' + otvarqne + #10#13 + 'Добавяне на запис: ' +
    dobavqne + #10#13 + 'Изтриване: ' + iztrivane);
end;

end.
