unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit3;

type
  TForm2 = class(TForm)
    Panel1: TPanel;
    LabeledEdit1: TLabeledEdit;
    LabeledEdit2: TLabeledEdit;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Label1: TLabel;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);    
    procedure Button3Click(Sender: TObject);
    procedure LabeledEdit1KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

procedure TForm2.Button3Click(Sender: TObject);
begin
  Form2.Close;
end;

procedure TForm2.Button2Click(Sender: TObject);
begin
  LabeledEdit1.Text := '';
  LabeledEdit2.Text := '';
end;

procedure TForm2.Button1Click(Sender: TObject);
var
  diplomna: TDiplomnaRabota;
  isExist: boolean;
  isChecked: boolean;
begin
  if (LabeledEdit1.Text = '') then begin
    ShowMessage('Моля въведете пореден номер!');
  end
  else if (LabeledEdit2.Text = '') then begin
    ShowMessage('Моля въведете наименованието на темата!');
  end
  else begin
    isExist := false;
    isChecked := false;
    {$I-}
    Reset(infF);
    {$I+}
    if IOResult = 0 then begin
      isChecked := true;
      while not Eof(infF) do begin
        Read(infF, diplomna);
        if (LabeledEdit1.Text = diplomna.por_nom) then begin
          isExist := true;
          ShowMessage('Съществува дипломна работа с този пореден номер!');
          break;
        end;
      end;
      CloseFile(infF);
      end
    else begin
      ShowMessage('Файлът не е намерен');
    end;

    if (isExist = false) and (isChecked) then begin
      {$I-}
      Reset(infF);
      {$I+}
      if IOResult = 0 then begin
        diplomna.por_nom := Form2.LabeledEdit1.Text;
        diplomna.tema_ime := Form2.LabeledEdit2.Text;
        diplomna.ezik_za_progr := '';
        diplomna.tip_pril := '';
        diplomna.rukovoditel := '';
        diplomna.student := '';
        diplomna.fac_nom := '';
        diplomna.zaet := 0;
        Seek(infF, FileSize(infF));
        Write(infF, diplomna);
        CloseFile(infF);
    
        ShowMessage('Записът е добавен');
        dobavqne := '+';
        Button2Click(Sender);
        Form2.Close;
      end
      else begin
        ShowMessage('Файлът не е намерен');
      end;
    end;
  end;
end;

procedure TForm2.LabeledEdit1KeyPress(Sender: TObject; var Key: Char);
begin
  if (Key in ['0'..'9', #8] = false) then begin
    Key := #0;
  end;
end;

end.
