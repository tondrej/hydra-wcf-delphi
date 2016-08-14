program DelphiHostConsole;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,
  uHYModuleManager,
  WcfService1ClientPluginModule_Import in 'WcfService1ClientPluginModule_Import.pas';

procedure Main;
var
  ModuleManager: THYModuleManager;
  ModuleIndex: Integer;
  Instance: IInterface;
  Client: IService1Client;
  m1p1: Integer;
  m1r, m3p1, m3r: WideString;
  m2p1, m2r: CompositeType;
begin
  ModuleIndex := -1;
  ModuleManager := THYModuleManager.Create(nil);
  try
    ModuleIndex := ModuleManager.LoadManagedModule('WcfService1ClientPluginModule.dll', False);
    if ModuleIndex = -1 then
      Exit;

    ModuleManager.CreateInstance('WcfService1ClientPluginModule.WcfService1ClientPlugin', Instance);
    if not Supports(Instance, IService1Client, Client) then
      Exit;

    m1p1 := 42;
    m1r := Client.GetData(m1p1);
    Writeln(Format('GetData(%d): ''%s''', [m1p1, m1r]));

    m2p1.BoolValue := True;
    m2p1.StringValue := 'Hi';
    m2r := Client.GetDataUsingDataContract(m2p1);
    Writeln(Format('GetDataUsingDataContract(%s, ''%s''): %s, ''%s''',
      [BoolToStr(m2p1.BoolValue, True), m2p1.StringValue, BoolToStr(m2r.BoolValue, True), m2r.StringValue]));

    m3p1 := 'world';
    m3r := Client.Hello(m3p1);
    Writeln(Format('Hello(''%s''): ''%s''', [m3p1, m3r]));

    Readln;
  finally
    Client := nil;
    Instance := nil;
    if ModuleIndex <> -1 then
      ModuleManager.UnloadModule(ModuleIndex);
    ModuleManager.Free;
  end;
end;

begin
  try
    Main;
  except
    on E: Exception do
    begin
      ExitCode := 1;
      Writeln(Format('[%s] %s', [E.ClassName, E.Message]));
    end;
  end;
end.
