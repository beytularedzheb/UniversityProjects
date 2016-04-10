unit SourceCodeAbout;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Buttons, ShellAPI;

type
  TformAbout = class(TForm)
    lblAppName: TLabel;
    pnlContent: TPanel;
    lblVersion: TLabel;
    lblBuil: TLabel;
    lblFacebook: TLabel;
    lblCreatedBy: TLabel;
    lblCrName: TLabel;
    webAddress: TStaticText;
    lblCopyright: TLabel;
    lblInfo: TLabel;
    lblUniversity: TLabel;
    btnClose: TSpeedButton;
    procedure btnCloseClick(Sender: TObject);
    procedure webAddressClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  formAbout: TformAbout;

implementation

{$R *.dfm}

procedure TformAbout.btnCloseClick(Sender: TObject);
begin
  Close;
end;

procedure TformAbout.webAddressClick(Sender: TObject);
begin
{$IFDEF MSWINDOWS}
  ShellExecute(0, 'OPEN', PChar('https://www.facebook.com/thesilent91'), '', '', SW_SHOWNORMAL);
{$ENDIF MSWINDOWS}
{$IFDEF POSIX}
  _system(PAnsiChar('open ' + AnsiString('https://www.facebook.com/thesilent91')));
{$ENDIF POSIX}
end;

end.
