unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Button2: TButton;
    Panel1: TPanel;
    Button3: TButton;
    Label1: TLabel;
    Label2: TLabel;
    Button4: TButton;
    Button5: TButton;
    RichEdit1: TRichEdit;
    Button6: TButton;
    Label3: TLabel;
    Label4: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Button6Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  beginSeans, EndSeans: string;

implementation
uses Unit2, Unit3;

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  searchCom := '-';
  addCom := '-';
  closeF1 := '-';
  closeF2 := '-';
  editCom := '-';
  deleteCom := '-';
  restoreCom := '-';
  
  beginSeans := DateTimeToStr(Now);
  Panel1.Visible := false;
  AssignFile(indF, 'index.ind');
  AssignFile(infF, 'commands.txt');
  {$I-} Reset(infF); {$I+}
  if ioresult <> 0 then
    ShowMessage('Грешка при отваряне на информационния файл!')
  else begin
    {$I-} Reset(indF); {$I+}
    if ioresult <> 0 then
      ShowMessage('Грешка при отваряне на индексния файл!')
    else
      Label4.Caption := IntToStr(FileSize(infF));
  end;
  CloseFile(infF); CloseFile(indF);
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  closeF1 := '+';
  ShowMessage('Подадени са следните команди:' + #13#10 +
               #13#10 + searchCom + ' Търсене на команда;'  +
               #13#10 + addCom + ' Добавяне на нова команда;' +
               #13#10 + editCom + ' Редактиране на данни;' +
               #13#10 + deleteCom + ' Изтриване на данни;' +
               #13#10 + restoreCom + ' Възстановяване на данни;' +
               #13#10 + closeF2 + ' Затваряне на формата за добавяне;' +
               #13#10 + closeF1 + ' Изход от програмата.');
  endSeans := DateTimeToStr(Now);
  ShowMessage('СЕАНС:' + #13#10 + 'Начало:  ' + beginSeans + #13#10 + 'Край: ' + endSeans);
  Form1.Close;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Form2.Show;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  searchCom := '+';
  if Edit1.Text='' then begin
    Panel1.Visible := false;
    ShowMessage('Не сте въвели команда/ключ за търсене!');
  end
  else begin
    Panel1.Visible := false;
    positionFound := Search(LowerCase(Edit1.Text));
    if (positionFound <> -1) then begin
      Panel1.Visible := true;
      {$I-} Reset(infF); {$I+}
      if ioresult <> 0 then
        ShowMessage('Грешка при отваряне на информационния файл!')
      else begin
        Seek(infF, positionFound);
        Read(infF, komanda);
        CloseFile(infF);
        Label2.Caption := komanda.komanda;
        RichEdit1.Lines.Text := komanda.opisanie;

        if komanda.deleted = true then begin
          Button4.Enabled := false;
          Button5.Enabled := false;
          Button6.Enabled := true;
          RichEdit1.Enabled := false;
        end
        else begin
          Button4.Enabled := true;
          Button5.Enabled := true;
          Button6.Enabled := false;
          RichEdit1.Enabled := true;
        end;
      end;
    end;
  end;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  editCom := '+';
  if (RichEdit1.Text = '') then
    ShowMessage('Въведете описание!')
  else begin
    {$I-} Reset(infF); {$I+}
    if ioresult <> 0 then
      ShowMessage('Грешка при отваряне на информационния файл!')
    else begin
      Seek(infF, positionFound);
      komanda.opisanie := RichEdit1.Lines.Text;
      write(infF, komanda);
      ShowMessage('Данните за "' + komanda.komanda + '" са променени!');
      CloseFile(infF);
    end;
  end;
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if Key = #13 then
    Button1.OnClick(Sender);
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
    restoreCom := '(+)';
    {$I-} Reset(infF); {$I+}
    if ioresult <> 0 then
      ShowMessage('Грешка при отваряне на информационния файл!')
    else begin
      Reset(infF);
      Seek(infF, positionFound);
      komanda.deleted := false;
      write(infF, komanda);
      ShowMessage('Командата "' + komanda.komanda + '" е възстановена!');
      CloseFile(infF);

      Button4.Enabled := true;
      Button5.Enabled := true;
      Button6.Enabled := false;
      RichEdit1.Enabled := true;
    end;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  deleteCom := '+';
    {$I-} Reset(infF); {$I+}
    if ioresult <> 0 then
      ShowMessage('Грешка при отваряне на информационния файл!')
    else begin
      Reset(infF);
      Seek(infF, positionFound);
      komanda.deleted := true;
      write(infF, komanda);
      ShowMessage('Командата "' + komanda.komanda + '" е изтрита!');
      CloseFile(infF);

      Button4.Enabled := false;
      Button5.Enabled := false;
      Button6.Enabled := true;
      RichEdit1.Enabled := false;
    end;
end;

end.
