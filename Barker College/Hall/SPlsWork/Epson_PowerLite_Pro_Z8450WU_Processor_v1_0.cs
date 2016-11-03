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

namespace UserModule_EPSON_POWERLITE_PRO_Z8450WU_PROCESSOR_V1_0
{
    public class UserModuleClass_EPSON_POWERLITE_PRO_Z8450WU_PROCESSOR_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CONTRAST;
        Crestron.Logos.SplusObjects.AnalogOutput BRIGHTNESS;
        Crestron.Logos.SplusObjects.AnalogOutput COLOR;
        Crestron.Logos.SplusObjects.AnalogOutput TINT;
        Crestron.Logos.SplusObjects.AnalogOutput SHARPNESS;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME;
        Crestron.Logos.SplusObjects.AnalogOutput LAMP;
        ushort SEMAPHORE = 0;
        CrestronString TEMP__DOLLAR__;
        object FROM_DEVICE__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 95;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEMAPHORE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 97;
                    SEMAPHORE = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 98;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u000D" , FROM_DEVICE__DOLLAR__ ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 101;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "=" , FROM_DEVICE__DOLLAR__ ) > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 103;
                            TEMP__DOLLAR__  .UpdateValue ( Functions.Remove ( "\u000D" , FROM_DEVICE__DOLLAR__ )  ) ; 
                            __context__.SourceCodeLine = 104;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "CONTRAST" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 106;
                                CONTRAST  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 108;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "BRIGHT" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 110;
                                    BRIGHTNESS  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 112;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "DENSITY" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 114;
                                        COLOR  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 116;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "TINT" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 118;
                                            TINT  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 120;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "SHARP" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 122;
                                                SHARPNESS  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 124;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "VOL" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 126;
                                                    VOLUME  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 128;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "LAMP" , TEMP__DOLLAR__ ) > 0 ))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 130;
                                                        LAMP  .Value = (ushort) ( Functions.Atoi( TEMP__DOLLAR__ ) ) ; 
                                                        } 
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            __context__.SourceCodeLine = 132;
                            Functions.ClearBuffer ( TEMP__DOLLAR__ ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 98;
                        } 
                    
                    __context__.SourceCodeLine = 136;
                    SEMAPHORE = (ushort) ( 0 ) ; 
                    } 
                
                
                
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
            
            __context__.SourceCodeLine = 147;
            SEMAPHORE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 148;
            Functions.ClearBuffer ( FROM_DEVICE__DOLLAR__ ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        TEMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        CONTRAST = new Crestron.Logos.SplusObjects.AnalogOutput( CONTRAST__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( CONTRAST__AnalogSerialOutput__, CONTRAST );
        
        BRIGHTNESS = new Crestron.Logos.SplusObjects.AnalogOutput( BRIGHTNESS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( BRIGHTNESS__AnalogSerialOutput__, BRIGHTNESS );
        
        COLOR = new Crestron.Logos.SplusObjects.AnalogOutput( COLOR__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( COLOR__AnalogSerialOutput__, COLOR );
        
        TINT = new Crestron.Logos.SplusObjects.AnalogOutput( TINT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( TINT__AnalogSerialOutput__, TINT );
        
        SHARPNESS = new Crestron.Logos.SplusObjects.AnalogOutput( SHARPNESS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SHARPNESS__AnalogSerialOutput__, SHARPNESS );
        
        VOLUME = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( VOLUME__AnalogSerialOutput__, VOLUME );
        
        LAMP = new Crestron.Logos.SplusObjects.AnalogOutput( LAMP__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( LAMP__AnalogSerialOutput__, LAMP );
        
        FROM_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__DOLLAR____AnalogSerialInput__, 100, this );
        m_StringInputList.Add( FROM_DEVICE__DOLLAR____AnalogSerialInput__, FROM_DEVICE__DOLLAR__ );
        
        
        FROM_DEVICE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_EPSON_POWERLITE_PRO_Z8450WU_PROCESSOR_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FROM_DEVICE__DOLLAR____AnalogSerialInput__ = 0;
    const uint CONTRAST__AnalogSerialOutput__ = 0;
    const uint BRIGHTNESS__AnalogSerialOutput__ = 1;
    const uint COLOR__AnalogSerialOutput__ = 2;
    const uint TINT__AnalogSerialOutput__ = 3;
    const uint SHARPNESS__AnalogSerialOutput__ = 4;
    const uint VOLUME__AnalogSerialOutput__ = 5;
    const uint LAMP__AnalogSerialOutput__ = 6;
    
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
