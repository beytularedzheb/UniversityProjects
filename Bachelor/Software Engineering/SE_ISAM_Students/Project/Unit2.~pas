unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, ComCtrls, Menus;

type
  TForm1 = class(TForm)
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
    Edit7: TEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Label9: TLabel;
    Bevel2: TBevel;
    OpenDialog1: TOpenDialog;
    SaveDialog1: TSaveDialog;
    Button4: TButton;
    Panel2: TPanel;
    procedure FormCreate(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Edit6KeyPress(Sender: TObject; var Key: Char);
    procedure Edit7KeyPress(Sender: TObject; var Key: Char);
    procedure Edit3KeyPress(Sender: TObject; var Key: Char);
    procedure Edit4KeyPress(Sender: TObject; var Key: Char);
    procedure Edit5KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  fname: string;
  inFname: string;
  opened: boolean;
  startD: string;
  stopD: string;

implementation
uses Unit1, Unit3;

{$R *.dfm}


procedure TForm1.FormCreate(Sender: TObject);
begin
  Button6.Top := 120;
  Button7.Top := 120;
  Button8.Top := 120;
  Bevel2.Top := 100;
  Form1.Height := 210;
  Panel1.Visible := false;
  fname := '';
  inFname := '';
  startD := DateTimeToStr(Now);

  tyrs:='(-)';
  dob:='(-)';
  red:='(-)';
  iztr:='(-)';
  vyzst:='(-)';
  syzd:='(-)';
  otv:='(-)';
  izhod:='(-)';
  izch:='(-)';
  zatv:='(-)';
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  Form2.Show;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  tyrs:='(+)';
  if ((fname = '') or (inFname = '')) then
    ShowMessage('Не е избран файл за четене!')
  else begin
  if Edit1.Text='' then
    ShowMessage('Не сте въвели ключ/фак. номер за търсене')
  else begin
    Panel1.Visible := false;
    positionFound := Search(StrToInt(Edit1.Text));
    if (positionFound <> -1) then begin
      Panel1.Visible := true;
      Reset(infF);
      Seek(infF,positionFound);
      Read(infF,student);
      CloseFile(infF);
      Edit2.Text := student.fac_num;
      Edit3.Text := student.first_name;
      Edit4.Text := student.sec_name;
      Edit5.Text := student.last_name;
      DateTimePicker1.Date := student.date_r;
      DateTimePicker2.Date := student.date_z;
      Edit6.Text := IntToStr(student.group);
      Edit7.Text := FloatToStr(student.sr_usp);
   
      Button6.Top := 480;
      Button7.Top := 480;
      Button8.Top := 480;
      Bevel2.Top := 456;
      Form1.Height :=570;
      if student.deleted = true then begin
          Button4.Visible := true;
          Button4.Top := 286;
          Button4.Left := 225;
          Edit3.Enabled := false;
          Edit4.Enabled := false;
          Edit5.Enabled := false;
          DateTimePicker1.Enabled := false;
          DateTimePicker2.Enabled := false;
          Edit6.Enabled := false;
          Edit7.Enabled := false;
          Panel2.Visible:= false;
      end
      else begin
          Button4.Visible := false;
          Edit3.Enabled := true;
          Edit4.Enabled := true;
          Edit5.Enabled := true;
          DateTimePicker1.Enabled := true;
          DateTimePicker2.Enabled := true;
          Edit6.Enabled := true;
          Edit7.Enabled := true;
          Panel2.Visible:= true;
      end;
    end
    else begin
      Button6.Top := 120;
      Button7.Top := 120;
      Button8.Top := 120;
      Bevel2.Top := 100;
      Form1.Height := 210;
    end;
  end;
   end;
end;

procedure TForm1.Button8Click(Sender: TObject);
begin
  izhod:='(+)';
  ShowMessage('Подадени са следните команди:' + #13#10 +
               #13#10 + tyrs + ' Търсене на студент;'  +
               #13#10 + dob + ' Добавяне на нов студент;' +
               #13#10 + red + ' Редактиране на данни;' +
               #13#10 + iztr + ' Изтриване на данни;' +
               #13#10 + vyzst + ' Възстановяване на данни;' +
               #13#10 + syzd + ' Създаване на нов файл;' +
               #13#10 + otv + ' Отваряне на файл;' +
               #13#10 + izch + ' Изчистване на данни;' +
               #13#10 + zatv + ' Затваряне на формата за добавяне;' +
               #13#10 + izhod + ' Изход от програмата.');
  stopD := DateTimeToStr(Now);
  ShowMessage('Начало:  ' + startD + #13#10 + 'Край: ' + stopD);
  Form1.Close;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  syzd:='(+)';
  opened := false;
  ShowMessage('Запишете иформационния файл!');
  if (Form1.SaveDialog1.Execute) then begin
    fname := Form1.SaveDialog1.FileName;
    Form1.Caption := fname;
    AssignFile(infF, fname);
    Rewrite(infF);
    opened := true;
    CloseFile(infF);
  end;
  if (opened = true) then begin
    ShowMessage('Запишете индексния файл!');
    if (Form1.SaveDialog1.Execute) then begin
      inFname := Form1.SaveDialog1.FileName;
      AssignFile(indF, inFname);
      Rewrite(indF);
      CloseFile(indF);

      Edit1.Text := '';
      Button6.Top := 120;
      Button7.Top := 120;
      Button8.Top := 120;
      Bevel2.Top := 100;
      Form1.Height := 210;
      Panel1.Visible := false;
    end;
  end;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  otv:='(+)';
  opened := false;
  ShowMessage('Изберете информационния файл!');
  if (Form1.OpenDialog1.Execute) then begin
	  fname := Form1.OpenDialog1.FileName;
	  Form1.Caption := fname;
    AssignFile(infF, fname);
    opened := true;
  end;
  if (opened = true) then begin
    ShowMessage('Изберете индексния файл!');
    if (Form1.OpenDialog1.Execute) then begin
	    inFname := Form1.OpenDialog1.FileName;
      AssignFile(indF, inFname);

      Edit1.Text := '';
      Button6.Top := 120;
      Button7.Top := 120;
      Button8.Top := 120;
      Bevel2.Top := 100;
      Form1.Height := 210;
      Panel1.Visible := false;
    end;
  end;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
    iztr:='(+)';
    if student.deleted = false then begin
      Button4.Visible := false;
      Reset(infF,fname);
      Seek(infF, positionFound);
      student.deleted := true;
      write(infF, student);
      ShowMessage('Данните за студент с факултетен номер: '+student.fac_num+' са изтрити!');
      CloseFile(infF);

      Button4.Visible := true;
      Button4.Top := 286;
      Button4.Left := 225;
      Edit3.Enabled := false;
      Edit4.Enabled := false;
      Edit5.Enabled := false;
      DateTimePicker1.Enabled := false;
      DateTimePicker2.Enabled := false;
      Edit6.Enabled := false;
      Edit7.Enabled := false;
      Panel2.Visible:= false;
    end;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
    vyzst:='(+)';
    if student.deleted = true then begin
      Reset(infF,fname);
      Seek(infF, positionFound);
      student.deleted := false;
      write(infF, student);
      ShowMessage('Данните за студент с факултетен номер: '+student.fac_num+' са възстановени!');
      CloseFile(infF);

      Button4.Visible := false;
      Edit3.Enabled := true;
      Edit4.Enabled := true;
      Edit5.Enabled := true;
      DateTimePicker1.Enabled := true;
      DateTimePicker2.Enabled := true;
      Edit6.Enabled := true;
      Edit7.Enabled := true;
      Panel2.Visible:= true;
    end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  red:= '(+)';
  if (Edit3.Text='') then
    ShowMessage('Въведете име!')
  else if (Edit4.Text='') then
    ShowMessage('Въведете презиме!')
  else if (Edit5.Text='') then
    ShowMessage('Въведете фамилия!')
  else if (DateTimePicker1.Format=' ') then
    ShowMessage('Въведете дата на раждане!')
  else if (DateTimePicker2.Format=' ') then
    ShowMessage('Въведете дата на записване!')
  else if (Edit6.Text='') then
    ShowMessage('Въведете група!')
  else if (Edit7.Text='') then
    ShowMessage('Въведете среден успех!')
  else if ((StrToFloat(Edit7.Text)<2) or (StrToFloat(Edit7.Text)>6)) then
    ShowMessage('Средният успех трябва да е между 2 и 6!')
  else if student.deleted = false then begin
          Reset(infF);
          Seek(infF, positionFound);
          student.first_name := Edit3.Text;
          student.sec_name := Edit4.Text;
          student.last_name := Edit5.Text;
          student.date_r := DateTimePicker1.Date;
          student.date_z := DateTimePicker2.Date;
          student.group := StrToInt(Edit6.Text);
          student.sr_usp := StrToFloat(Edit7.Text);
          student.deleted := false;
          write(infF, student);
          ShowMessage('Данните за студент с факултетен номер: '+student.fac_num+' са променени!');
          CloseFile(infF);
  end;
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8,#13] = false then
    Key := #10;
  if Key = #13 then
        Button1.OnClick(Sender);
end;

procedure TForm1.Edit6KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8] = false then
    Key := #10;
end;

procedure TForm1.Edit7KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9',#8,#44] = false then
    Key := #10;
end;

procedure TForm1.Edit3KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

procedure TForm1.Edit4KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

procedure TForm1.Edit5KeyPress(Sender: TObject; var Key: Char);
begin
  if Key in ['0'..'9'] = true then
    Key := #10;
end;

end.


