unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls;

type
  TForm2 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Edit2: TEdit;
    Edit3: TEdit;
    Label3: TLabel;
    Label4: TLabel;
    Edit4: TEdit;
    Label5: TLabel;
    DateTimePicker1: TDateTimePicker;
    Label6: TLabel;
    DateTimePicker2: TDateTimePicker;
    Label7: TLabel;
    Edit5: TEdit;
    Label8: TLabel;
    Edit6: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Label9: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure DateTimePicker1Change(Sender: TObject);
    procedure DateTimePicker2Change(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormCreate(Sender: TObject);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure Edit5KeyPress(Sender: TObject; var Key: Char);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Edit2KeyPress(Sender: TObject; var Key: Char);
    procedure Edit3KeyPress(Sender: TObject; var Key: Char);
    procedure Edit4KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation
uses Unit3, Unit2;


{$R *.dfm}



procedure TForm2.Button1Click(Sender: TObject);
begin
  dob:='(+)';
  if (Edit1.Text='') then
    ShowMessage('Въведете факултетен номер!')
  else if (length(Edit1.Text)<>6)then
    ShowMessage('Въвели сте невалиден факултетен номер!')
  else if (Edit2.Text='') then
    ShowMessage('Въведете име!')
  else if (Edit3.Text='') then
    ShowMessage('Въведете презиме!')
  else if (Edit4.Text='') then
    ShowMessage('Въведете фамилия!')
  else if (DateTimePicker1.Format=' ') then
    ShowMessage('Въведете дата на раждане!')
  else if (DateTimePicker2.Format=' ') then
    ShowMessage('Въведете дата на записване!')
  else if (Edit5.Text='') then
    ShowMessage('Въведете група!')
  else if (Edit6.Text='') then
    ShowMessage('Въведете среден успех!')
  else if ((StrToFloat(Edit6.Text)<2) or (StrToFloat(Edit6.Text)>6)) then
    ShowMessage('Средният успех трябва да е между 2 и 6!')
  else begin
    student.fac_num := Edit1.Text;
    student.first_name := Edit2.Text;
    student.sec_name := Edit3.Text;
    student.last_name := Edit4.Text;
    student.date_r := DateTimePicker1.Date;
    student.date_z := DateTimePicker2.Date;
    student.group := StrToInt(Edit5.Text);
    student.sr_usp := StrToFloat(Edit6.Text);
    student.deleted := false;
    if (fname <> '') then begin
      Reset(infF);
      Seek(infF, FileSize(infF));
      Write(infF, student);


      Reset(indF);
      Index.index := StrToInt(Edit1.Text);
      Index.position := FileSize(infF);
      CloseFile(infF);

      Seek(indF, FileSize(indF));
      write(indF, Index);
      CloseFile(indF);
      SortIndexFile();
      ShowMessage('Студентът е добавен!');
      Form2.Close;
    end
    else begin
      opened := false;
      ShowMessage('Запишете иформационния файл!');
      if (Form1.SaveDialog1.Execute) then begin
          opened := true;
          fname := Form1.SaveDialog1.FileName;
          AssignFile(infF, fname);
          Rewrite(infF);
          Write(infF, student);
          Index.index := StrToInt(Edit1.Text);
          Index.position := FileSize(infF);
          CloseFile(infF);
      end;
      if (opened = true) then begin
        ShowMessage('Запишете индексния файл!');
        if (Form1.SaveDialog1.Execute) then begin
            inFname := Form1.SaveDialog1.FileName;
            AssignFile(indF, inFname);
            Rewrite(indF);
            Write(indF, Index);
            CloseFile(indF);
            ShowMessage('Студентът е добавен!');
            Form2.Close;
			syzd:='(+)';
			
            Form1.Edit1.Text := '';
            Form1.Button6.Top := 120;
            Form1.Button7.Top := 120;
            Form1.Button8.Top := 120;
            Form1.Bevel2.Top := 100;
            Form1.Height := 210;
            Form1.Panel1.Visible := false;
        end;
      end;
    end;
  end;
end;

procedure TForm2.Button3Click(Sender: TObject);
begin
  zatv:='(+)';
  Form2.Close;
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
  izch:='(+)';
  Edit1.Text := '';
  Edit2.Text := '';
  Edit3.Text := '';
  Edit4.Text := '';
  DateTimePicker1.Format := ' ';
  DateTimePicker2.Format := ' ';
  Edit5.Text := '';
  Edit6.Text := '';
end;

procedure TForm2.DateTimePicker1Change(Sender: TObject);
begin
  DateTimePicker1.Format := ShortDateFormat;
end;

procedure TForm2.DateTimePicker2Change(Sender: TObject);
begin
  DateTimePicker2.Format := ShortDateFormat;
end;

procedure TForm2.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Edit1.Text := '';
  Edit2.Text := '';
  Edit3.Text := '';
  Edit4.Text := '';
  DateTimePicker1.Format := ' ';
  DateTimePicker2.Format := ' ';
  Edit5.Text := '';
  Edit6.Text := '';
end;

procedure TForm2.FormCreate(Sender: TObject);
begin
  Edit1.Text := '';
  Edit2.Text := '';
  Edit3.Text := '';
  Edit4.Text := '';
  DateTimePicker1.Format := ' ';
  DateTimePicker2.Format := ' ';
  Edit5.Text := '';
  Edit6.Text := '';
end;

procedure TForm2.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8,#44] = false then
    Key := #10;
end;

procedure TForm2.Edit5KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8] = false then
    Key := #10;
end;

procedure TForm2.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8] = false then
    Key := #10;
end;

procedure TForm2.Edit2KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

procedure TForm2.Edit3KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

procedure TForm2.Edit4KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

end.
