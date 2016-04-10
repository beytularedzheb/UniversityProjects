unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls;

type
  TForm2 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Edit1: TEdit;
    RichEdit1: TRichEdit;
    Label2: TLabel;
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation
uses Unit1, Unit3;

{$R *.dfm}

procedure TForm2.Button4Click(Sender: TObject);
begin
  addCom := '+';
  if (Edit1.Text = '') then
    ShowMessage('Моля въведете команда!')
  else if(RichEdit1.Lines.Capacity = 0) then
    ShowMessage('Моля въведете описание!')
  else begin
    komanda.komanda := Edit1.Text;
    komanda.opisanie := RichEdit1.Lines.Text;
    komanda.deleted := false;

    {$I-} Reset(infF); {$I+}
    if ioresult <> 0 then
      ShowMessage('Грешка при отварянето на информационния файл!')
    else begin
      {$I-} Reset(indF); {$I+}
      if ioresult <> 0 then
        ShowMessage('Грешка при отварянето на индексния файл!')
      else begin
        Seek(infF, FileSize(infF));
        Write(infF, komanda);

        Index.index := LowerCase(Edit1.Text);
        Index.position := FileSize(infF);
        Form1.Label4.Caption := IntToStr(FileSize(infF));
        CloseFile(infF);

        Seek(indF, FileSize(indF));
        write(indF, Index);
        CloseFile(indF);
        SortIndexFile();
        ShowMessage('Командата е добавена');
        Form2.Close;
      end;
    end;
  end;
end;

procedure TForm2.Button5Click(Sender: TObject);
begin
  Edit1.Text := '';
  RichEdit1.Lines.Clear;
end;

procedure TForm2.Button6Click(Sender: TObject);
begin
  closeF2 := '+';
  Form2.Close;
end;

procedure TForm2.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  Button5.OnClick(Sender);
end;

procedure TForm2.FormCreate(Sender: TObject);
begin
  Button5.OnClick(Sender);
end;

end.
