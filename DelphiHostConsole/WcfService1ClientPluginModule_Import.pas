unit WcfService1ClientPluginModule_Import;

{ This unit has been automatically created by Hydra. Any changes in this unit might be lost in automatic updates } 

interface

uses
  Winapi.Windows,
  uHYCrossPlatformInterfaces;

type
  CompositeType = record
    BoolValue: BOOL;
    StringValue: WideString;
  end;
  // Original Name: WcfService1ClientPluginModule.IService1Client
  IService1Client = interface(IHYCrossPlatformInterface)
  ['{8bfebd21-ebe2-4519-b744-5231219e1bed}']
    function GetData(const value: LongInt): WideString; safecall;
    function GetDataUsingDataContract(const composite: CompositeType): CompositeType; safecall;
    function Hello(const name: WideString): WideString; safecall;
  end;

implementation

end.
