using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_TIMESECONDSTOMINS
{
    public class UserModuleClass_TIMESECONDSTOMINS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.AnalogInput TIMERCOUNTDOWN;
        Crestron.Logos.SplusObjects.AnalogOutput TIMEOFMINS;
        Crestron.Logos.SplusObjects.AnalogOutput TIMEOFSECONDS;
        Crestron.Logos.SplusObjects.StringOutput TIMEOFMINS__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TIMEOFSECONDS__DOLLAR__;
        ushort ITEMP = 0;
        ushort IMINS = 0;
        ushort ISECONDS = 0;
        object TIMERCOUNTDOWN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 87;
                ITEMP = (ushort) ( TIMERCOUNTDOWN  .UshortValue ) ; 
                __context__.SourceCodeLine = 88;
                IMINS = (ushort) ( (ITEMP / 60) ) ; 
                __context__.SourceCodeLine = 89;
                ISECONDS = (ushort) ( Mod( ITEMP , 60 ) ) ; 
                __context__.SourceCodeLine = 90;
                TIMEOFMINS  .Value = (ushort) ( IMINS ) ; 
                __context__.SourceCodeLine = 91;
                TIMEOFSECONDS  .Value = (ushort) ( ISECONDS ) ; 
                __context__.SourceCodeLine = 92;
                TIMEOFMINS__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( IMINS ) )  ) ; 
                __context__.SourceCodeLine = 93;
                TIMEOFSECONDS__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( ISECONDS ) )  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 107;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        TIMERCOUNTDOWN = new Crestron.Logos.SplusObjects.AnalogInput( TIMERCOUNTDOWN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( TIMERCOUNTDOWN__AnalogSerialInput__, TIMERCOUNTDOWN );
        
        TIMEOFMINS = new Crestron.Logos.SplusObjects.AnalogOutput( TIMEOFMINS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( TIMEOFMINS__AnalogSerialOutput__, TIMEOFMINS );
        
        TIMEOFSECONDS = new Crestron.Logos.SplusObjects.AnalogOutput( TIMEOFSECONDS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( TIMEOFSECONDS__AnalogSerialOutput__, TIMEOFSECONDS );
        
        TIMEOFMINS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TIMEOFMINS__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TIMEOFMINS__DOLLAR____AnalogSerialOutput__, TIMEOFMINS__DOLLAR__ );
        
        TIMEOFSECONDS__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TIMEOFSECONDS__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TIMEOFSECONDS__DOLLAR____AnalogSerialOutput__, TIMEOFSECONDS__DOLLAR__ );
        
        
        TIMERCOUNTDOWN.OnAnalogChange.Add( new InputChangeHandlerWrapper( TIMERCOUNTDOWN_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_TIMESECONDSTOMINS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TIMERCOUNTDOWN__AnalogSerialInput__ = 0;
    const uint TIMEOFMINS__AnalogSerialOutput__ = 0;
    const uint TIMEOFSECONDS__AnalogSerialOutput__ = 1;
    const uint TIMEOFMINS__DOLLAR____AnalogSerialOutput__ = 2;
    const uint TIMEOFSECONDS__DOLLAR____AnalogSerialOutput__ = 3;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
