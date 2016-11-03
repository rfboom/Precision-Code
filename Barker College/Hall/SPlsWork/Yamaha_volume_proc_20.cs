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

namespace UserModule_YAMAHA_VOLUME_PROC_20
{
    public class UserModuleClass_YAMAHA_VOLUME_PROC_20 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SEND_STRING;
        Crestron.Logos.SplusObjects.DigitalInput SEND_QUERY;
        Crestron.Logos.SplusObjects.DigitalInput SEND_LEVEL_STRING;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_TO_BE;
        Crestron.Logos.SplusObjects.AnalogInput MOD_CONTROL_TYPE;
        Crestron.Logos.SplusObjects.StringInput CONTROL_VALUE;
        Crestron.Logos.SplusObjects.StringInput CONTROL_TYPE;
        Crestron.Logos.SplusObjects.StringInput CONTROL_CHANNEL;
        Crestron.Logos.SplusObjects.StringInput CONTROL_MATRIX;
        Crestron.Logos.SplusObjects.BufferInput MODULE_RXD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ISNEGATIVE;
        Crestron.Logos.SplusObjects.DigitalOutput PRESET_MUTE;
        Crestron.Logos.SplusObjects.DigitalOutput START_UP_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput CONTROL_VALUE_RET;
        Crestron.Logos.SplusObjects.StringOutput CONTROL_ALIAS_RET;
        Crestron.Logos.SplusObjects.StringOutput MODULE_TXD__DOLLAR__;
        ushort BRXOK = 0;
        ushort ISTEP = 0;
        ushort IMAXVOL = 0;
        ushort IMINVOL = 0;
        ushort IWAIT = 0;
        ushort ICTRLTYPE = 0;
        ushort IVOLINDEX1 = 0;
        ushort IVOLINDEX2 = 0;
        ushort IVOLUMESIGNED = 0;
        ushort IVOLUME = 0;
        ushort IINSTANCE = 0;
        ushort IVOLDOWNCALC = 0;
        ushort IMATRIX = 0;
        short ITEMPVOLLIMIT = 0;
        short INEWVOL = 0;
        short ISIGNEDMAX = 0;
        short ISIGNEDMIN = 0;
        short IVOLTOBE = 0;
        CrestronString STEMPDATA;
        CrestronString SVOL;
        CrestronString SVOLTEXT;
        CrestronString SVOLUMEPREFIX;
        CrestronString SVOLUMETYPE;
        CrestronString SINSTANCE;
        CrestronString SSTEP;
        CrestronString SSENDINST;
        CrestronString SMATRIX;
        CrestronString SSENDNAME;
        CrestronString SPAR1;
        CrestronString SPAR2;
        CrestronString SPAR3;
        CrestronString SPAR4;
        CrestronString SPAR5;
        CrestronString SCONTROL_CHANNEL;
        CrestronString SCONTROLVOL;
        private void SEND_OUT_NAME (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 100;
            MakeString ( MODULE_TXD__DOLLAR__ , "{0}={1}.{2}.{3}\r\n", SSENDNAME , SINSTANCE , SCONTROL_CHANNEL , SMATRIX ) ; 
            
            }
            
        object SEND_STRING_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 111;
                MakeString ( MODULE_TXD__DOLLAR__ , "set MTX:mem_512\u002F{0}\u002F{1}\u002F{2}\u002F{3}\u002F{4}\u002F{5} 0 0 {6}\u000A", Functions.ItoA (  (int) ( IINSTANCE ) ) , SPAR1 , SPAR2 , SPAR3 , SPAR4 , SPAR5 , SCONTROLVOL ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SEND_LEVEL_STRING_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 118;
            MakeString ( MODULE_TXD__DOLLAR__ , "set MTX:mem_512\u002F{0}\u002F{1}\u002F{2}\u002F{3}\u002F{4}\u002F{5} 0 0 {6:d}\u000A", Functions.ItoA (  (int) ( IINSTANCE ) ) , SPAR1 , SPAR2 , SPAR3 , SPAR4 , SPAR5 , (short)IVOLTOBE) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SEND_QUERY_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 123;
        MakeString ( MODULE_TXD__DOLLAR__ , "get MTX:mem_512\u002F{0}\u002F{1}\u002F{2}\u002F{3}\u002F{4}\u002F{5} 0 0\u000A", Functions.ItoA (  (int) ( IINSTANCE ) ) , SPAR1 , SPAR2 , SPAR3 , SPAR4 , SPAR5 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_TO_BE_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 128;
        IVOLTOBE = (short) ( (VOLUME_TO_BE  .ShortValue * 100) ) ; 
        __context__.SourceCodeLine = 129;
        IVOLTOBE = (short) ( (IVOLTOBE - 2000) ) ; 
        __context__.SourceCodeLine = 130;
        MakeString ( MODULE_TXD__DOLLAR__ , "set MTX:mem_512\u002F{0}\u002F{1}\u002F{2}\u002F{3}\u002F{4}\u002F{5} 0 0 {6:d}\u000A", Functions.ItoA (  (int) ( IINSTANCE ) ) , SPAR1 , SPAR2 , SPAR3 , SPAR4 , SPAR5 , (short)IVOLTOBE) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MOD_CONTROL_TYPE_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 136;
        ICTRLTYPE = (ushort) ( MOD_CONTROL_TYPE  .UshortValue ) ; 
        __context__.SourceCodeLine = 137;
        
            {
            int __SPLS_TMPVAR__SWTCH_1__ = ((int)ICTRLTYPE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 141;
                    SPAR1  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 142;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 143;
                    SPAR3  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 144;
                    SPAR4  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 145;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 149;
                    SPAR1  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 150;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 151;
                    SPAR3  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 152;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 153;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 157;
                    SPAR1  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 158;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 159;
                    SPAR3  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 160;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 161;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 165;
                    SPAR1  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 166;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 167;
                    SPAR3  .UpdateValue ( SMATRIX  ) ; 
                    __context__.SourceCodeLine = 168;
                    SPAR4  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 169;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 173;
                    SPAR1  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 174;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 175;
                    SPAR3  .UpdateValue ( SMATRIX  ) ; 
                    __context__.SourceCodeLine = 176;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 177;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 181;
                    SPAR1  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 182;
                    SPAR2  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 183;
                    SPAR3  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 184;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 185;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 189;
                    SPAR1  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 190;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 191;
                    SPAR3  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 192;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 193;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 197;
                    SPAR1  .UpdateValue ( "1"  ) ; 
                    __context__.SourceCodeLine = 198;
                    SPAR2  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 199;
                    SPAR3  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 200;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 201;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 205;
                    SPAR1  .UpdateValue ( "2"  ) ; 
                    __context__.SourceCodeLine = 206;
                    SPAR2  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 207;
                    SPAR3  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 208;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 209;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 213;
                    SPAR1  .UpdateValue ( "2"  ) ; 
                    __context__.SourceCodeLine = 214;
                    SPAR2  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 215;
                    SPAR3  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 216;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 217;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 221;
                    SPAR1  .UpdateValue ( "2"  ) ; 
                    __context__.SourceCodeLine = 222;
                    SPAR2  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 223;
                    SPAR3  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 224;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 225;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 229;
                    SPAR1  .UpdateValue ( "2"  ) ; 
                    __context__.SourceCodeLine = 230;
                    SPAR2  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 231;
                    SPAR3  .UpdateValue ( SCONTROL_CHANNEL  ) ; 
                    __context__.SourceCodeLine = 232;
                    SPAR4  .UpdateValue ( "0"  ) ; 
                    __context__.SourceCodeLine = 233;
                    SPAR5  .UpdateValue ( "0"  ) ; 
                    } 
                
                } 
                
            }
            
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MODULE_RXD__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMP1;
        CrestronString TEMP2;
        CrestronString TEMP3;
        TEMP1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        TEMP2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
        TEMP3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
        
        ushort INOTTEXTER = 0;
        
        
        __context__.SourceCodeLine = 243;
        if ( Functions.TestForTrue  ( ( BRXOK)  ) ) 
            { 
            __context__.SourceCodeLine = 245;
            BRXOK = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 246;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u000A" , MODULE_RXD__DOLLAR__ ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 248;
                TEMP1  .UpdateValue ( Functions.Gather ( "\u000A" , MODULE_RXD__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 249;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "Send Name\u000A" , TEMP1 ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 251;
                    START_UP_OUT  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 252;
                    SSENDNAME  .UpdateValue ( Functions.Left ( TEMP1 ,  (int) ( (Functions.Length( TEMP1 ) - 1) ) )  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 262;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "OFF" , TEMP1 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 264;
                        PRESET_MUTE  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 265;
                        INOTTEXTER = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 267;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "ON" , TEMP1 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 269;
                            PRESET_MUTE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 270;
                            INOTTEXTER = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 282;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "INFINITY" , TEMP1 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 284;
                                ISNEGATIVE  .Value = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 285;
                                CONTROL_VALUE_RET  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 289;
                                INOTTEXTER = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 293;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (INOTTEXTER == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 295;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "-" , TEMP1 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 297;
                            ISNEGATIVE  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 298;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( TEMP1 ) > 2000 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 301;
                                IVOLDOWNCALC = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 302;
                                CONTROL_VALUE_RET  .Value = (ushort) ( IVOLDOWNCALC ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 307;
                                IVOLDOWNCALC = (ushort) ( (2000 - Functions.Atoi( TEMP1 )) ) ; 
                                __context__.SourceCodeLine = 308;
                                IVOLDOWNCALC = (ushort) ( (IVOLDOWNCALC / 100) ) ; 
                                __context__.SourceCodeLine = 309;
                                CONTROL_VALUE_RET  .Value = (ushort) ( IVOLDOWNCALC ) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 314;
                            ISNEGATIVE  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 318;
                            IVOLDOWNCALC = (ushort) ( Functions.Atoi( TEMP1 ) ) ; 
                            __context__.SourceCodeLine = 319;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IVOLDOWNCALC == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 321;
                                IVOLDOWNCALC = (ushort) ( 2000 ) ; 
                                __context__.SourceCodeLine = 322;
                                IVOLDOWNCALC = (ushort) ( (IVOLDOWNCALC / 100) ) ; 
                                __context__.SourceCodeLine = 323;
                                CONTROL_VALUE_RET  .Value = (ushort) ( IVOLDOWNCALC ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 327;
                                IVOLDOWNCALC = (ushort) ( (IVOLDOWNCALC / 100) ) ; 
                                __context__.SourceCodeLine = 328;
                                CONTROL_VALUE_RET  .Value = (ushort) ( IVOLDOWNCALC ) ; 
                                } 
                            
                            } 
                        
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 246;
                } 
            
            __context__.SourceCodeLine = 335;
            BRXOK = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 337;
            INOTTEXTER = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 338;
            Functions.ProcessLogic ( ) ; 
            } 
        
        __context__.SourceCodeLine = 342;
        Functions.ClearBuffer ( TEMP1 ) ; 
        __context__.SourceCodeLine = 343;
        Functions.ClearBuffer ( TEMP2 ) ; 
        __context__.SourceCodeLine = 344;
        Functions.ClearBuffer ( TEMP3 ) ; 
        __context__.SourceCodeLine = 345;
        BRXOK = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONTROL_TYPE_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 351;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "\u0020" , CONTROL_TYPE ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 353;
            MakeString ( SINSTANCE , "\u0022{0}\u0022", Functions.Left ( CONTROL_TYPE ,  (int) ( 38 ) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 357;
            SINSTANCE  .UpdateValue ( Functions.Left ( CONTROL_TYPE ,  (int) ( 5 ) )  ) ; 
            __context__.SourceCodeLine = 358;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Mid( SINSTANCE , (int)( 2 ) , (int)( 1 ) ) == "1"))  ) ) 
                { 
                __context__.SourceCodeLine = 360;
                IINSTANCE = (ushort) ( Functions.Atoi( SINSTANCE ) ) ; 
                __context__.SourceCodeLine = 361;
                IINSTANCE = (ushort) ( (IINSTANCE - 1000) ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 366;
                IINSTANCE = (ushort) ( Functions.Atoi( SINSTANCE ) ) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 369;
        SCONTROL_CHANNEL  .UpdateValue ( CONTROL_CHANNEL  ) ; 
        __context__.SourceCodeLine = 370;
        SEND_OUT_NAME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONTROL_CHANNEL_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 375;
        SCONTROL_CHANNEL  .UpdateValue ( CONTROL_CHANNEL  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONTROL_MATRIX_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 380;
        SMATRIX  .UpdateValue ( CONTROL_MATRIX  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONTROL_VALUE_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 385;
        SCONTROLVOL  .UpdateValue ( CONTROL_VALUE  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 398;
        CONTROL_VALUE_RET  .Value = (ushort) ( 25 ) ; 
        __context__.SourceCodeLine = 399;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 400;
        BRXOK = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 401;
        SSTEP  .UpdateValue ( "1.0"  ) ; 
        __context__.SourceCodeLine = 402;
        ISTEP = (ushort) ( 10 ) ; 
        __context__.SourceCodeLine = 403;
        IWAIT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 404;
        IVOLUME = (ushort) ( 1000 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SVOL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    SVOLTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SVOLUMEPREFIX  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SVOLUMETYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SINSTANCE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 40, this );
    SSTEP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    SSENDINST  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SMATRIX  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SSENDNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SPAR1  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SPAR2  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SPAR3  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SPAR4  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SPAR5  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SCONTROL_CHANNEL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
    SCONTROLVOL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    
    SEND_STRING = new Crestron.Logos.SplusObjects.DigitalInput( SEND_STRING__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_STRING__DigitalInput__, SEND_STRING );
    
    SEND_QUERY = new Crestron.Logos.SplusObjects.DigitalInput( SEND_QUERY__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_QUERY__DigitalInput__, SEND_QUERY );
    
    SEND_LEVEL_STRING = new Crestron.Logos.SplusObjects.DigitalInput( SEND_LEVEL_STRING__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_LEVEL_STRING__DigitalInput__, SEND_LEVEL_STRING );
    
    ISNEGATIVE = new Crestron.Logos.SplusObjects.DigitalOutput( ISNEGATIVE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISNEGATIVE__DigitalOutput__, ISNEGATIVE );
    
    PRESET_MUTE = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_MUTE__DigitalOutput__, this );
    m_DigitalOutputList.Add( PRESET_MUTE__DigitalOutput__, PRESET_MUTE );
    
    START_UP_OUT = new Crestron.Logos.SplusObjects.DigitalOutput( START_UP_OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( START_UP_OUT__DigitalOutput__, START_UP_OUT );
    
    VOLUME_TO_BE = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_TO_BE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_TO_BE__AnalogSerialInput__, VOLUME_TO_BE );
    
    MOD_CONTROL_TYPE = new Crestron.Logos.SplusObjects.AnalogInput( MOD_CONTROL_TYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MOD_CONTROL_TYPE__AnalogSerialInput__, MOD_CONTROL_TYPE );
    
    CONTROL_VALUE_RET = new Crestron.Logos.SplusObjects.AnalogOutput( CONTROL_VALUE_RET__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CONTROL_VALUE_RET__AnalogSerialOutput__, CONTROL_VALUE_RET );
    
    CONTROL_VALUE = new Crestron.Logos.SplusObjects.StringInput( CONTROL_VALUE__AnalogSerialInput__, 10, this );
    m_StringInputList.Add( CONTROL_VALUE__AnalogSerialInput__, CONTROL_VALUE );
    
    CONTROL_TYPE = new Crestron.Logos.SplusObjects.StringInput( CONTROL_TYPE__AnalogSerialInput__, 40, this );
    m_StringInputList.Add( CONTROL_TYPE__AnalogSerialInput__, CONTROL_TYPE );
    
    CONTROL_CHANNEL = new Crestron.Logos.SplusObjects.StringInput( CONTROL_CHANNEL__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( CONTROL_CHANNEL__AnalogSerialInput__, CONTROL_CHANNEL );
    
    CONTROL_MATRIX = new Crestron.Logos.SplusObjects.StringInput( CONTROL_MATRIX__AnalogSerialInput__, 2, this );
    m_StringInputList.Add( CONTROL_MATRIX__AnalogSerialInput__, CONTROL_MATRIX );
    
    CONTROL_ALIAS_RET = new Crestron.Logos.SplusObjects.StringOutput( CONTROL_ALIAS_RET__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONTROL_ALIAS_RET__AnalogSerialOutput__, CONTROL_ALIAS_RET );
    
    MODULE_TXD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MODULE_TXD__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MODULE_TXD__DOLLAR____AnalogSerialOutput__, MODULE_TXD__DOLLAR__ );
    
    MODULE_RXD__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( MODULE_RXD__DOLLAR____AnalogSerialInput__, 1024, this );
    m_StringInputList.Add( MODULE_RXD__DOLLAR____AnalogSerialInput__, MODULE_RXD__DOLLAR__ );
    
    
    SEND_STRING.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_STRING_OnPush_0, false ) );
    SEND_LEVEL_STRING.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_LEVEL_STRING_OnPush_1, false ) );
    SEND_QUERY.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_QUERY_OnPush_2, false ) );
    VOLUME_TO_BE.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_TO_BE_OnChange_3, true ) );
    MOD_CONTROL_TYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( MOD_CONTROL_TYPE_OnChange_4, true ) );
    MODULE_RXD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( MODULE_RXD__DOLLAR___OnChange_5, true ) );
    CONTROL_TYPE.OnSerialChange.Add( new InputChangeHandlerWrapper( CONTROL_TYPE_OnChange_6, true ) );
    CONTROL_CHANNEL.OnSerialChange.Add( new InputChangeHandlerWrapper( CONTROL_CHANNEL_OnChange_7, false ) );
    CONTROL_MATRIX.OnSerialChange.Add( new InputChangeHandlerWrapper( CONTROL_MATRIX_OnChange_8, false ) );
    CONTROL_VALUE.OnSerialChange.Add( new InputChangeHandlerWrapper( CONTROL_VALUE_OnChange_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_YAMAHA_VOLUME_PROC_20 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SEND_STRING__DigitalInput__ = 0;
const uint SEND_QUERY__DigitalInput__ = 1;
const uint SEND_LEVEL_STRING__DigitalInput__ = 2;
const uint VOLUME_TO_BE__AnalogSerialInput__ = 0;
const uint MOD_CONTROL_TYPE__AnalogSerialInput__ = 1;
const uint CONTROL_VALUE__AnalogSerialInput__ = 2;
const uint CONTROL_TYPE__AnalogSerialInput__ = 3;
const uint CONTROL_CHANNEL__AnalogSerialInput__ = 4;
const uint CONTROL_MATRIX__AnalogSerialInput__ = 5;
const uint MODULE_RXD__DOLLAR____AnalogSerialInput__ = 6;
const uint ISNEGATIVE__DigitalOutput__ = 0;
const uint PRESET_MUTE__DigitalOutput__ = 1;
const uint START_UP_OUT__DigitalOutput__ = 2;
const uint CONTROL_VALUE_RET__AnalogSerialOutput__ = 0;
const uint CONTROL_ALIAS_RET__AnalogSerialOutput__ = 1;
const uint MODULE_TXD__DOLLAR____AnalogSerialOutput__ = 2;

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
