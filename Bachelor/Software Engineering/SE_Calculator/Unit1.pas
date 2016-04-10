unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Menus;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Button13: TButton;
    Button14: TButton;
    Button15: TButton;
    Button16: TButton;
    Button18: TButton;
    Button19: TButton;
    Button17: TButton;
    Button21: TButton;
    Button22: TButton;
    Button23: TButton;
    Button25: TButton;
    Button26: TButton;
    Button27: TButton;
    procedure Button13Click(Sender: TObject);
    procedure Button16Click(Sender: TObject);
    procedure Button14Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button17Click(Sender: TObject);
    procedure Button23Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button15Click(Sender: TObject);
    procedure Button22Click(Sender: TObject);
    procedure Button19Click(Sender: TObject);
    procedure Button21Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button18Click(Sender: TObject);
    procedure Button26Click(Sender: TObject);
    procedure Button25Click(Sender: TObject);
    procedure Button27Click(Sender: TObject);
  private
    { Private declarations }
    op1, op2: real;
    operation: integer;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button13Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '1'
  else
  Edit1.Text := Edit1.Text + '1';
end;

procedure TForm1.Button16Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '2'
  else
  Edit1.Text := Edit1.Text + '2';
end;

procedure TForm1.Button14Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '3'
  else
  Edit1.Text := Edit1.Text + '3';
end;

procedure TForm1.Button9Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '4'
  else
  Edit1.Text := Edit1.Text + '4';
end;

procedure TForm1.Button12Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '5'
  else
  Edit1.Text := Edit1.Text + '5';
end;

procedure TForm1.Button10Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '6'
  else
  Edit1.Text := Edit1.Text + '6';
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '7'
  else
  Edit1.Text := Edit1.Text + '7';
end;

procedure TForm1.Button8Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '8'
  else
  Edit1.Text := Edit1.Text + '8';
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  if Edit1.Text = '0' then
    Edit1.Text := '9'
  else
  Edit1.Text := Edit1.Text + '9';
end;

procedure TForm1.Button17Click(Sender: TObject);
begin
  if (Edit1.Text = '') or (Edit1.Text = '0') then
    Edit1.Text := '0'
  else
    Edit1.Text := Edit1.Text + '0';
end;

procedure TForm1.Button23Click(Sender: TObject);
begin
  if Edit1.Text = '' then
    Edit1.Text := Edit1.Text + '0,'
  else
    Edit1.Text := Edit1.Text + ',';
  Button23.Enabled := FALSE;
end;

procedure TForm1.Button11Click(Sender: TObject);
begin
  if Edit1.Text <> '' then begin
    op1 := StrToFloat(Edit1.Text);
    operation := 1;
    Edit1.Text := '';
    Button23.Enabled := TRUE;
  end;
end;

procedure TForm1.Button15Click(Sender: TObject);
begin
  if Edit1.Text <> '' then begin
    op1 := StrToFloat(Edit1.Text);
    operation := 2;
    Edit1.Text := '';
    Button23.Enabled := TRUE;
  end;
end;

procedure TForm1.Button22Click(Sender: TObject);
begin
  if Edit1.Text <> '' then begin
    op1 := StrToFloat(Edit1.Text);
    operation := 3;
    Edit1.Text := '';
    Button23.Enabled := TRUE;
  end;
end;

procedure TForm1.Button19Click(Sender: TObject);
begin
  if Edit1.Text <> '' then begin
    op1 := StrToFloat(Edit1.Text);
    operation := 4;
    Edit1.Text := '';
    Button23.Enabled := TRUE;
  end;
end;

procedure TForm1.Button21Click(Sender: TObject);
begin
  if ((Edit1.Text <> '') and (operation > 0)) then
    op2 := StrToFloat(Edit1.Text);
  Case operation of
    1: begin
        if op2 <> 0 then
          Edit1.Text := FloatToStr(op1 / op2)
        else if op2 = 0 then
          Edit1.Text := 'NaN';
       end;
    2: Edit1.Text := FloatToStr(op1 * op2);
    3: Edit1.Text := FloatToStr(op1 - op2);
    4: Edit1.Text := FloatToStr(op1 + op2);
  end;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  Edit1.Text := '';
  op1 := 0;
  op2 := 0;
  operation := 0;
  Button23.Enabled := TRUE;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(sin(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(cos(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(arctan(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button18Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(exp(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button26Click(Sender: TObject);
begin
   if ((Edit1.Text <> '') and (Edit1.Text <> '0')) then
    Edit1.Text := FloatToStr(ln(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button25Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(sqr(StrToFloat(Edit1.Text)));
end;

procedure TForm1.Button27Click(Sender: TObject);
begin
  if Edit1.Text <> '' then
    Edit1.Text := FloatToStr(sqrt(StrToFloat(Edit1.Text)));
end;

end.
