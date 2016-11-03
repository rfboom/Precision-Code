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

namespace UserModule_ROLAND_V40HD
{
    public class UserModuleClass_ROLAND_V40HD : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput STATUS_CHECK;
        Crestron.Logos.SplusObjects.DigitalInput MEMORY_LOAD;
        Crestron.Logos.SplusObjects.DigitalInput SOURCE_HDMI;
        Crestron.Logos.SplusObjects.DigitalInput SOURCE_RGB;
        Crestron.Logos.SplusObjects.DigitalInput SOURCE_COMPOSITE;
        Crestron.Logos.SplusObjects.DigitalInput SOURCE_SHARED;
        Crestron.Logos.SplusObjects.DigitalInput OUTPUT_FADE;
        Crestron.Logos.SplusObjects.DigitalInput AUTO_SWITCHING_START;
        Crestron.Logos.SplusObjects.DigitalInput DSK_SWITCHING_START;
        Crestron.Logos.SplusObjects.AnalogInput PIP_SELECT;
        Crestron.Logos.SplusObjects.AnalogInput PGM_SELECT;
        Crestron.Logos.SplusObjects.AnalogInput PST_SELECT;
        Crestron.Logos.SplusObjects.AnalogInput TRANSITION_PATTERN_SELECT;
        Crestron.Logos.SplusObjects.AnalogInput TRANSITION_TIME;
        Crestron.Logos.SplusObjects.AnalogInput MEMORY_SELECT;
        Crestron.Logos.SplusObjects.BufferInput ROLAND_RXD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput SOURCE_HDMI_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SOURCE_RGB_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SOURCE_COMPOSITE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SOURCE_SHARED_FB;
        Crestron.Logos.SplusObjects.StringOutput ROLAND_TXD__DOLLAR__;
        ushort IPIP = 0;
        ushort IPGM = 0;
        ushort IPST = 0;
        ushort ITPS = 0;
        ushort IMEMORY = 0;
        ushort ITEMP = 0;
        ushort IREAD = 0;
        ushort IFADE = 0;
        ushort ITRTIME = 0;
        private void SENDSTRING (  SplusExecutionContext __context__, CrestronString SCMD ) 
            { 
            
            __context__.SourceCodeLine = 164;
            MakeString ( ROLAND_TXD__DOLLAR__ , "{0}{1};", Functions.Chr ( 2 ) , SCMD ) ; 
            
            }
            
        private void SETACTIVESOURCE (  SplusExecutionContext __context__, ushort SRCACT ) 
            { 
            
            __context__.SourceCodeLine = 169;
            SOURCE_HDMI_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 170;
            SOURCE_RGB_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 171;
            SOURCE_COMPOSITE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 172;
            SOURCE_SHARED_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 173;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)SRCACT);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 177;
                        SOURCE_HDMI_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 181;
                        SOURCE_RGB_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 185;
                        SOURCE_COMPOSITE_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 189;
                        SOURCE_SHARED_FB  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        object STATUS_CHECK_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 201;
                SENDSTRING (  __context__ , "ACS") ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MEMORY_LOAD_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
            
            
            __context__.SourceCodeLine = 207;
            MakeString ( STEMP , "MEM:{0:d}", (short)IMEMORY) ; 
            __context__.SourceCodeLine = 208;
            SENDSTRING (  __context__ , STEMP) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SOURCE_HDMI_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 213;
        SENDSTRING (  __context__ , "HRC:0") ; 
        __context__.SourceCodeLine = 214;
        SETACTIVESOURCE (  __context__ , (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCE_RGB_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 219;
        SENDSTRING (  __context__ , "HRC:1") ; 
        __context__.SourceCodeLine = 220;
        SETACTIVESOURCE (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCE_COMPOSITE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 225;
        SENDSTRING (  __context__ , "HRC:2") ; 
        __context__.SourceCodeLine = 226;
        SETACTIVESOURCE (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SOURCE_SHARED_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 231;
        SENDSTRING (  __context__ , "HRC:3") ; 
        __context__.SourceCodeLine = 232;
        SETACTIVESOURCE (  __context__ , (ushort)( 3 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OUTPUT_FADE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 238;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IFADE == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 240;
            IFADE = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 244;
            IFADE = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 247;
        MakeString ( STEMP , "FDE:{0:d}", (short)IFADE) ; 
        __context__.SourceCodeLine = 248;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUTO_SWITCHING_START_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 254;
        SENDSTRING (  __context__ , "ATO") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DSK_SWITCHING_START_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 259;
        SENDSTRING (  __context__ , "DSK") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PIP_SELECT_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 265;
        IPIP = (ushort) ( PIP_SELECT  .UshortValue ) ; 
        __context__.SourceCodeLine = 266;
        MakeString ( STEMP , "PIP:{0:d}", (short)IPIP) ; 
        __context__.SourceCodeLine = 267;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PGM_SELECT_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 273;
        IPGM = (ushort) ( PGM_SELECT  .UshortValue ) ; 
        __context__.SourceCodeLine = 274;
        MakeString ( STEMP , "PGM:{0:d}", (short)IPGM) ; 
        __context__.SourceCodeLine = 275;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PST_SELECT_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 281;
        IPST = (ushort) ( PST_SELECT  .UshortValue ) ; 
        __context__.SourceCodeLine = 282;
        MakeString ( STEMP , "PST:{0:d}", (short)IPST) ; 
        __context__.SourceCodeLine = 283;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TRANSITION_PATTERN_SELECT_OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 289;
        ITPS = (ushort) ( TRANSITION_PATTERN_SELECT  .UshortValue ) ; 
        __context__.SourceCodeLine = 290;
        MakeString ( STEMP , "TRS:{0:d}", (short)ITPS) ; 
        __context__.SourceCodeLine = 291;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TRANSITION_TIME_OnChange_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        
        __context__.SourceCodeLine = 297;
        ITRTIME = (ushort) ( TRANSITION_TIME  .UshortValue ) ; 
        __context__.SourceCodeLine = 298;
        MakeString ( STEMP , "TIM:{0:d}", (short)ITRTIME) ; 
        __context__.SourceCodeLine = 299;
        SENDSTRING (  __context__ , STEMP) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MEMORY_SELECT_OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 304;
        IMEMORY = (ushort) ( MEMORY_SELECT  .UshortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROLAND_RXD__DOLLAR___OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        
        
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
        
        __context__.SourceCodeLine = 325;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    STATUS_CHECK = new Crestron.Logos.SplusObjects.DigitalInput( STATUS_CHECK__DigitalInput__, this );
    m_DigitalInputList.Add( STATUS_CHECK__DigitalInput__, STATUS_CHECK );
    
    MEMORY_LOAD = new Crestron.Logos.SplusObjects.DigitalInput( MEMORY_LOAD__DigitalInput__, this );
    m_DigitalInputList.Add( MEMORY_LOAD__DigitalInput__, MEMORY_LOAD );
    
    SOURCE_HDMI = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_HDMI__DigitalInput__, this );
    m_DigitalInputList.Add( SOURCE_HDMI__DigitalInput__, SOURCE_HDMI );
    
    SOURCE_RGB = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_RGB__DigitalInput__, this );
    m_DigitalInputList.Add( SOURCE_RGB__DigitalInput__, SOURCE_RGB );
    
    SOURCE_COMPOSITE = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_COMPOSITE__DigitalInput__, this );
    m_DigitalInputList.Add( SOURCE_COMPOSITE__DigitalInput__, SOURCE_COMPOSITE );
    
    SOURCE_SHARED = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE_SHARED__DigitalInput__, this );
    m_DigitalInputList.Add( SOURCE_SHARED__DigitalInput__, SOURCE_SHARED );
    
    OUTPUT_FADE = new Crestron.Logos.SplusObjects.DigitalInput( OUTPUT_FADE__DigitalInput__, this );
    m_DigitalInputList.Add( OUTPUT_FADE__DigitalInput__, OUTPUT_FADE );
    
    AUTO_SWITCHING_START = new Crestron.Logos.SplusObjects.DigitalInput( AUTO_SWITCHING_START__DigitalInput__, this );
    m_DigitalInputList.Add( AUTO_SWITCHING_START__DigitalInput__, AUTO_SWITCHING_START );
    
    DSK_SWITCHING_START = new Crestron.Logos.SplusObjects.DigitalInput( DSK_SWITCHING_START__DigitalInput__, this );
    m_DigitalInputList.Add( DSK_SWITCHING_START__DigitalInput__, DSK_SWITCHING_START );
    
    SOURCE_HDMI_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE_HDMI_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOURCE_HDMI_FB__DigitalOutput__, SOURCE_HDMI_FB );
    
    SOURCE_RGB_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE_RGB_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOURCE_RGB_FB__DigitalOutput__, SOURCE_RGB_FB );
    
    SOURCE_COMPOSITE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE_COMPOSITE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOURCE_COMPOSITE_FB__DigitalOutput__, SOURCE_COMPOSITE_FB );
    
    SOURCE_SHARED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE_SHARED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOURCE_SHARED_FB__DigitalOutput__, SOURCE_SHARED_FB );
    
    PIP_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( PIP_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PIP_SELECT__AnalogSerialInput__, PIP_SELECT );
    
    PGM_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( PGM_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PGM_SELECT__AnalogSerialInput__, PGM_SELECT );
    
    PST_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( PST_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PST_SELECT__AnalogSerialInput__, PST_SELECT );
    
    TRANSITION_PATTERN_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( TRANSITION_PATTERN_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TRANSITION_PATTERN_SELECT__AnalogSerialInput__, TRANSITION_PATTERN_SELECT );
    
    TRANSITION_TIME = new Crestron.Logos.SplusObjects.AnalogInput( TRANSITION_TIME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TRANSITION_TIME__AnalogSerialInput__, TRANSITION_TIME );
    
    MEMORY_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( MEMORY_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MEMORY_SELECT__AnalogSerialInput__, MEMORY_SELECT );
    
    ROLAND_TXD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ROLAND_TXD__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ROLAND_TXD__DOLLAR____AnalogSerialOutput__, ROLAND_TXD__DOLLAR__ );
    
    ROLAND_RXD__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( ROLAND_RXD__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( ROLAND_RXD__DOLLAR____AnalogSerialInput__, ROLAND_RXD__DOLLAR__ );
    
    
    STATUS_CHECK.OnDigitalPush.Add( new InputChangeHandlerWrapper( STATUS_CHECK_OnPush_0, false ) );
    MEMORY_LOAD.OnDigitalPush.Add( new InputChangeHandlerWrapper( MEMORY_LOAD_OnPush_1, false ) );
    SOURCE_HDMI.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE_HDMI_OnPush_2, false ) );
    SOURCE_RGB.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE_RGB_OnPush_3, false ) );
    SOURCE_COMPOSITE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE_COMPOSITE_OnPush_4, false ) );
    SOURCE_SHARED.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE_SHARED_OnPush_5, false ) );
    OUTPUT_FADE.OnDigitalPush.Add( new InputChangeHandlerWrapper( OUTPUT_FADE_OnPush_6, false ) );
    AUTO_SWITCHING_START.OnDigitalPush.Add( new InputChangeHandlerWrapper( AUTO_SWITCHING_START_OnPush_7, false ) );
    DSK_SWITCHING_START.OnDigitalPush.Add( new InputChangeHandlerWrapper( DSK_SWITCHING_START_OnPush_8, false ) );
    PIP_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( PIP_SELECT_OnChange_9, false ) );
    PGM_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( PGM_SELECT_OnChange_10, false ) );
    PST_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( PST_SELECT_OnChange_11, false ) );
    TRANSITION_PATTERN_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( TRANSITION_PATTERN_SELECT_OnChange_12, false ) );
    TRANSITION_TIME.OnAnalogChange.Add( new InputChangeHandlerWrapper( TRANSITION_TIME_OnChange_13, false ) );
    MEMORY_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( MEMORY_SELECT_OnChange_14, false ) );
    ROLAND_RXD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( ROLAND_RXD__DOLLAR___OnChange_15, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ROLAND_V40HD ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint STATUS_CHECK__DigitalInput__ = 0;
const uint MEMORY_LOAD__DigitalInput__ = 1;
const uint SOURCE_HDMI__DigitalInput__ = 2;
const uint SOURCE_RGB__DigitalInput__ = 3;
const uint SOURCE_COMPOSITE__DigitalInput__ = 4;
const uint SOURCE_SHARED__DigitalInput__ = 5;
const uint OUTPUT_FADE__DigitalInput__ = 6;
const uint AUTO_SWITCHING_START__DigitalInput__ = 7;
const uint DSK_SWITCHING_START__DigitalInput__ = 8;
const uint PIP_SELECT__AnalogSerialInput__ = 0;
const uint PGM_SELECT__AnalogSerialInput__ = 1;
const uint PST_SELECT__AnalogSerialInput__ = 2;
const uint TRANSITION_PATTERN_SELECT__AnalogSerialInput__ = 3;
const uint TRANSITION_TIME__AnalogSerialInput__ = 4;
const uint MEMORY_SELECT__AnalogSerialInput__ = 5;
const uint ROLAND_RXD__DOLLAR____AnalogSerialInput__ = 6;
const uint SOURCE_HDMI_FB__DigitalOutput__ = 0;
const uint SOURCE_RGB_FB__DigitalOutput__ = 1;
const uint SOURCE_COMPOSITE_FB__DigitalOutput__ = 2;
const uint SOURCE_SHARED_FB__DigitalOutput__ = 3;
const uint ROLAND_TXD__DOLLAR____AnalogSerialOutput__ = 0;

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
