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

namespace UserModule_YAMAHAMTX_PROCESSOR
{
    public class UserModuleClass_YAMAHAMTX_PROCESSOR : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SEND_NEXT;
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput GET_NEXT_NAME;
        Crestron.Logos.SplusObjects.BufferInput DEVICE_RXD__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput MODULES_RXD__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput TIMED_OUT;
        Crestron.Logos.SplusObjects.DigitalOutput INITIALIZE_BUSY;
        Crestron.Logos.SplusObjects.DigitalOutput NAME_TIMED_OUT;
        Crestron.Logos.SplusObjects.StringOutput DEVICE_TXD__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput CONTROL_ALIAS_RET;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_MODULES;
        ushort INEXTCOMMANDSTORE = 0;
        ushort INEXTCOMMANDSEND = 0;
        ushort INEXTGETSTORE = 0;
        ushort INEXTGETSEND = 0;
        ushort ITEMPID = 0;
        ushort ITEMPCH = 0;
        ushort ITEMPRT = 0;
        ushort BFLAG1 = 0;
        ushort BFLAG2 = 0;
        ushort BOKTOSEND = 0;
        ushort ITEMP = 0;
        ushort A = 0;
        ushort B = 0;
        ushort ISENDNAME = 0;
        ushort ITEMP1 = 0;
        ushort ITEMP2 = 0;
        ushort ITEMP3 = 0;
        ushort ITEMP4 = 0;
        ushort ITEMP5 = 0;
        ushort ITEMP6 = 0;
        ushort ITEMP7 = 0;
        ushort ITEMP8 = 0;
        ushort ITEMP9 = 0;
        ushort ITEMP10 = 0;
        ushort ITEMP11 = 0;
        uint ITEMPDEVID = 0;
        uint ILTEMP3 = 0;
        CrestronString [] SCOMMAND;
        CrestronString [] SGET;
        CrestronString STEMPMODULES;
        CrestronString STEMPDEVICE;
        CrestronString STEMPDEVICECH;
        CrestronString [] SMODULEINSTANCEID;
        CrestronString TEMP1;
        CrestronString TEMP2;
        CrestronString TEMP3;
        CrestronString TEMP4;
        CrestronString TEMP5;
        CrestronString TEMP6;
        CrestronString TEMP7;
        CrestronString TEMP8;
        CrestronString TEMP9;
        CrestronString TEMP10;
        CrestronString TRASH;
        private void FTIMEOUT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 97;
            CreateWait ( "WTIMEOUT" , 200 , WTIMEOUT_Callback ) ;
            
            }
            
        public void WTIMEOUT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 99;
            TIMED_OUT  .Value = (ushort) ( 1 ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void FNAMETIMEOUT (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 105;
        CreateWait ( "WNAMETIMEOUT" , 40 , WNAMETIMEOUT_Callback ) ;
        
        }
        
    public void WNAMETIMEOUT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 107;
            NAME_TIMED_OUT  .Value = (ushort) ( 1 ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void FSENDWAKEUP (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 113;
    CreateWait ( "WWAKEUP" , 10 , WWAKEUP_Callback ) ;
    
    }
    
public void WWAKEUP_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 115;
            DEVICE_TXD__DOLLAR__  .UpdateValue ( "devstatus runmode\u000A"  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object INITIALIZE_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 126;
        FSENDWAKEUP (  __context__  ) ; 
        __context__.SourceCodeLine = 127;
        INITIALIZE_BUSY  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 128;
        BOKTOSEND = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 129;
        ISENDNAME = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 130;
        MakeString ( TO_MODULES [ ISENDNAME] , "{0:d} {1}", (short)ISENDNAME, "Send Name\u000A" ) ; 
        __context__.SourceCodeLine = 131;
        FNAMETIMEOUT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SEND_NEXT_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 136;
        TIMED_OUT  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SEND_NEXT_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SCOMMAND[ INEXTCOMMANDSEND ] ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 143;
            DEVICE_TXD__DOLLAR__  .UpdateValue ( SCOMMAND [ INEXTCOMMANDSEND ]  ) ; 
            __context__.SourceCodeLine = 144;
            SCOMMAND [ INEXTCOMMANDSEND ]  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 145;
            FTIMEOUT (  __context__  ) ; 
            __context__.SourceCodeLine = 146;
            BOKTOSEND = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 147;
            INEXTCOMMANDSEND = (ushort) ( (INEXTCOMMANDSEND + 1) ) ; 
            __context__.SourceCodeLine = 148;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTCOMMANDSEND > 500 ))  ) ) 
                { 
                __context__.SourceCodeLine = 150;
                INEXTCOMMANDSEND = (ushort) ( 1 ) ; 
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 153;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SGET[ INEXTGETSEND ] ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 155;
                DEVICE_TXD__DOLLAR__  .UpdateValue ( SGET [ INEXTGETSEND ]  ) ; 
                __context__.SourceCodeLine = 156;
                SGET [ INEXTGETSEND ]  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 157;
                FTIMEOUT (  __context__  ) ; 
                __context__.SourceCodeLine = 158;
                BOKTOSEND = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 159;
                INEXTGETSEND = (ushort) ( (INEXTGETSEND + 1) ) ; 
                __context__.SourceCodeLine = 160;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTGETSEND > 500 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 162;
                    INEXTGETSEND = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 167;
                BOKTOSEND = (ushort) ( 1 ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GET_NEXT_NAME_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 173;
        Functions.Delay (  (int) ( 1 ) ) ; 
        __context__.SourceCodeLine = 174;
        NAME_TIMED_OUT  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 175;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISENDNAME < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 177;
            SMODULEINSTANCEID [ ISENDNAME ]  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 178;
            ISENDNAME = (ushort) ( (ISENDNAME + 1) ) ; 
            __context__.SourceCodeLine = 179;
            MakeString ( TO_MODULES [ ISENDNAME] , "{0:d} {1}", (short)ISENDNAME, "Send Name\u000A" ) ; 
            __context__.SourceCodeLine = 180;
            FNAMETIMEOUT (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 182;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISENDNAME == 100))  ) ) 
                { 
                __context__.SourceCodeLine = 184;
                INITIALIZE_BUSY  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 185;
                BOKTOSEND = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 186;
                TIMED_OUT  .Value = (ushort) ( 1 ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MODULES_RXD__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 192;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BFLAG1 == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 194;
            BFLAG1 = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 195;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 197;
                STEMPMODULES  .UpdateValue ( Functions.Gather ( "\u000A" , MODULES_RXD__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 198;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "Send Name" , STEMPMODULES ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 201;
                    TRASH  .UpdateValue ( Functions.Remove ( "=" , STEMPMODULES )  ) ; 
                    __context__.SourceCodeLine = 202;
                    ITEMPID = (ushort) ( Functions.Atoi( TRASH ) ) ; 
                    __context__.SourceCodeLine = 203;
                    TRASH  .UpdateValue ( Functions.Remove ( "." , STEMPMODULES )  ) ; 
                    __context__.SourceCodeLine = 204;
                    ITEMPDEVID = (uint) ( Functions.Atol( TRASH ) ) ; 
                    __context__.SourceCodeLine = 205;
                    ITEMPCH = (ushort) ( Functions.Atoi( STEMPMODULES ) ) ; 
                    __context__.SourceCodeLine = 206;
                    TRASH  .UpdateValue ( Functions.Remove ( "." , STEMPMODULES )  ) ; 
                    __context__.SourceCodeLine = 207;
                    ITEMPRT = (ushort) ( Functions.Atoi( STEMPMODULES ) ) ; 
                    __context__.SourceCodeLine = 209;
                    MakeString ( SMODULEINSTANCEID [ ITEMPID ] , "{0:d}.{1:d}.{2:d}\u000A", (int)ITEMPDEVID, (short)ITEMPCH, (short)ITEMPRT) ; 
                    __context__.SourceCodeLine = 211;
                    CancelWait ( "WNAMETIMEOUT" ) ; 
                    __context__.SourceCodeLine = 212;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ISENDNAME < 100 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 214;
                        ISENDNAME = (ushort) ( (ISENDNAME + 1) ) ; 
                        __context__.SourceCodeLine = 215;
                        MakeString ( TO_MODULES [ ISENDNAME] , "{0:d} {1}", (short)ISENDNAME, "Send Name\u000A" ) ; 
                        __context__.SourceCodeLine = 216;
                        FNAMETIMEOUT (  __context__  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 220;
                        INITIALIZE_BUSY  .Value = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 221;
                        BOKTOSEND = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 222;
                        TIMED_OUT  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 225;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BOKTOSEND == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 227;
                        DEVICE_TXD__DOLLAR__  .UpdateValue ( STEMPMODULES  ) ; 
                        __context__.SourceCodeLine = 228;
                        FTIMEOUT (  __context__  ) ; 
                        __context__.SourceCodeLine = 229;
                        BOKTOSEND = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 231;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "GET" , STEMPMODULES ) > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 233;
                            SGET [ INEXTGETSTORE ]  .UpdateValue ( STEMPMODULES  ) ; 
                            __context__.SourceCodeLine = 234;
                            INEXTGETSTORE = (ushort) ( (INEXTGETSTORE + 1) ) ; 
                            __context__.SourceCodeLine = 235;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTGETSTORE > 500 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 237;
                                INEXTGETSTORE = (ushort) ( 1 ) ; 
                                } 
                            
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 242;
                            SCOMMAND [ INEXTCOMMANDSTORE ]  .UpdateValue ( STEMPMODULES  ) ; 
                            __context__.SourceCodeLine = 243;
                            INEXTCOMMANDSTORE = (ushort) ( (INEXTCOMMANDSTORE + 1) ) ; 
                            __context__.SourceCodeLine = 244;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTCOMMANDSTORE > 500 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 246;
                                INEXTCOMMANDSTORE = (ushort) ( 1 ) ; 
                                } 
                            
                            } 
                        
                        }
                    
                    }
                
                __context__.SourceCodeLine = 249;
                STEMPMODULES  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 195;
                } 
            
            __context__.SourceCodeLine = 251;
            BFLAG1 = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEVICE_RXD__DOLLAR___OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INOTTEXTER = 0;
        
        CrestronString PROCESSBUFFER__DOLLAR__;
        PROCESSBUFFER__DOLLAR__  = new CrestronString( InheritedStringEncoding, 5000, this );
        
        
        __context__.SourceCodeLine = 261;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BFLAG2 == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 264;
            BFLAG2 = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 265;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 267;
                TEMP1  .UpdateValue ( Functions.Gather ( "\u000A" , DEVICE_RXD__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 268;
                if ( Functions.TestForTrue  ( ( Functions.Find( "ERROR" , TEMP1 , 1 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 269;
                    TEMP1  .UpdateValue ( ""  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 270;
                    if ( Functions.TestForTrue  ( ( Functions.Find( "runmode" , TEMP1 , 1 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 271;
                        TEMP1  .UpdateValue ( ""  ) ; 
                        }
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 274;
                        CancelWait ( "WTIMEOUT" ) ; 
                        __context__.SourceCodeLine = 275;
                        TEMP2  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 276;
                        TEMP3  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 277;
                        TEMP4  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 278;
                        TEMP5  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 279;
                        TEMP6  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 280;
                        TEMP7  .UpdateValue ( Functions.Remove ( "\u002F" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 281;
                        TEMP8  .UpdateValue ( Functions.Remove ( "\u0020" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 282;
                        TEMP9  .UpdateValue ( Functions.Remove ( "\u0020" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 283;
                        TEMP10  .UpdateValue ( Functions.Remove ( "\u0020" , TEMP1 )  ) ; 
                        __context__.SourceCodeLine = 287;
                        ILTEMP3 = (uint) ( Functions.Atol( TEMP3 ) ) ; 
                        __context__.SourceCodeLine = 288;
                        ITEMP4 = (ushort) ( Functions.Atoi( TEMP4 ) ) ; 
                        __context__.SourceCodeLine = 289;
                        ITEMP5 = (ushort) ( Functions.Atoi( TEMP5 ) ) ; 
                        __context__.SourceCodeLine = 290;
                        ITEMP6 = (ushort) ( Functions.Atoi( TEMP6 ) ) ; 
                        __context__.SourceCodeLine = 291;
                        ITEMP7 = (ushort) ( Functions.Atoi( TEMP7 ) ) ; 
                        __context__.SourceCodeLine = 292;
                        ITEMP8 = (ushort) ( Functions.Atoi( TEMP8 ) ) ; 
                        __context__.SourceCodeLine = 293;
                        ITEMP11 = (ushort) ( Functions.Atoi( TEMP1 ) ) ; 
                        __context__.SourceCodeLine = 298;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILTEMP3 == 60000))  ) ) 
                            { 
                            __context__.SourceCodeLine = 300;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP4 > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 302;
                                STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                __context__.SourceCodeLine = 303;
                                MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP6 ) ) ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 307;
                                ILTEMP3 = (uint) ( (ILTEMP3 + 1000) ) ; 
                                __context__.SourceCodeLine = 308;
                                STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                __context__.SourceCodeLine = 309;
                                MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP5 ) ) ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 312;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILTEMP3 == 60001))  ) ) 
                                { 
                                __context__.SourceCodeLine = 314;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP4 > 0 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 316;
                                    STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                    __context__.SourceCodeLine = 317;
                                    MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP6 ) ) ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 321;
                                    ILTEMP3 = (uint) ( (ILTEMP3 + 1000) ) ; 
                                    __context__.SourceCodeLine = 322;
                                    STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                    __context__.SourceCodeLine = 323;
                                    MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP5 ) ) ) ; 
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 326;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILTEMP3 == 30002))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 328;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP7 > 0 ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 330;
                                        STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 334;
                                        ILTEMP3 = (uint) ( (ILTEMP3 + 1000) ) ; 
                                        __context__.SourceCodeLine = 335;
                                        STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                        } 
                                    
                                    __context__.SourceCodeLine = 337;
                                    MakeString ( STEMPDEVICECH , "{0}.{1}.{2}\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP5 ) ) , Functions.ItoA (  (int) ( ITEMP6 ) ) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 339;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILTEMP3 == 20024))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 341;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITEMP4 > 0 ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 343;
                                            ILTEMP3 = (uint) ( (ILTEMP3 + 1000) ) ; 
                                            __context__.SourceCodeLine = 344;
                                            STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 348;
                                            STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                            } 
                                        
                                        __context__.SourceCodeLine = 350;
                                        MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP5 ) ) ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 352;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILTEMP3 == 20023))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 354;
                                            STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                            __context__.SourceCodeLine = 355;
                                            MakeString ( STEMPDEVICECH , "{0}.{1}.{2}\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP11 ) ) , Functions.ItoA (  (int) ( ITEMP6 ) ) ) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 359;
                                            STEMPDEVICE  .UpdateValue ( Functions.LtoA (  (int) ( ILTEMP3 ) )  ) ; 
                                            __context__.SourceCodeLine = 360;
                                            MakeString ( STEMPDEVICECH , "{0}.{1}.0\u000A", STEMPDEVICE , Functions.ItoA (  (int) ( ITEMP5 ) ) ) ; 
                                            } 
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 369;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "NORMAL" , Functions.Upper( TEMP2 ) ) == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "SSRECALL" , Functions.Upper( TEMP2 ) ) == 0) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "ERROR" , Functions.Upper( TEMP2 ) ) == 0) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 371;
                            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__1 = (ushort)100; 
                            int __FN_FORSTEP_VAL__1 = (int)1; 
                            for ( B  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (B  >= __FN_FORSTART_VAL__1) && (B  <= __FN_FOREND_VAL__1) ) : ( (B  <= __FN_FORSTART_VAL__1) && (B  >= __FN_FOREND_VAL__1) ) ; B  += (ushort)__FN_FORSTEP_VAL__1) 
                                { 
                                __context__.SourceCodeLine = 373;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( SMODULEINSTANCEID[ B ] ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Find( SMODULEINSTANCEID[ B ] , STEMPDEVICECH ) > 0 ) )) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 375;
                                    TO_MODULES [ B]  .UpdateValue ( TEMP1  ) ; 
                                    __context__.SourceCodeLine = 377;
                                    break ; 
                                    } 
                                
                                else 
                                    { 
                                    } 
                                
                                __context__.SourceCodeLine = 371;
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 385;
                        Functions.Delay (  (int) ( 5 ) ) ; 
                        __context__.SourceCodeLine = 386;
                        BOKTOSEND = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 387;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SCOMMAND[ INEXTCOMMANDSEND ] ) > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 389;
                            DEVICE_TXD__DOLLAR__  .UpdateValue ( SCOMMAND [ INEXTCOMMANDSEND ]  ) ; 
                            __context__.SourceCodeLine = 390;
                            SCOMMAND [ INEXTCOMMANDSEND ]  .UpdateValue ( ""  ) ; 
                            __context__.SourceCodeLine = 391;
                            FTIMEOUT (  __context__  ) ; 
                            __context__.SourceCodeLine = 392;
                            BOKTOSEND = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 393;
                            INEXTCOMMANDSEND = (ushort) ( (INEXTCOMMANDSEND + 1) ) ; 
                            __context__.SourceCodeLine = 394;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTCOMMANDSEND > 500 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 396;
                                INEXTCOMMANDSEND = (ushort) ( 1 ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 399;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SGET[ INEXTGETSEND ] ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 401;
                                DEVICE_TXD__DOLLAR__  .UpdateValue ( SGET [ INEXTGETSEND ]  ) ; 
                                __context__.SourceCodeLine = 402;
                                SGET [ INEXTGETSEND ]  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 403;
                                FTIMEOUT (  __context__  ) ; 
                                __context__.SourceCodeLine = 404;
                                BOKTOSEND = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 405;
                                INEXTGETSEND = (ushort) ( (INEXTGETSEND + 1) ) ; 
                                __context__.SourceCodeLine = 406;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( INEXTGETSEND > 500 ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 408;
                                    INEXTGETSEND = (ushort) ( 1 ) ; 
                                    } 
                                
                                } 
                            
                            }
                        
                        __context__.SourceCodeLine = 411;
                        TEMP1  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 412;
                        CONTROL_ALIAS_RET  .UpdateValue ( ""  ) ; 
                        __context__.SourceCodeLine = 413;
                        Functions.ClearBuffer ( TEMP1 ) ; 
                        __context__.SourceCodeLine = 414;
                        Functions.ClearBuffer ( TEMP2 ) ; 
                        __context__.SourceCodeLine = 415;
                        Functions.ClearBuffer ( TEMP3 ) ; 
                        __context__.SourceCodeLine = 416;
                        Functions.ClearBuffer ( TEMP4 ) ; 
                        __context__.SourceCodeLine = 417;
                        Functions.ClearBuffer ( TEMP5 ) ; 
                        __context__.SourceCodeLine = 418;
                        Functions.ClearBuffer ( TEMP6 ) ; 
                        __context__.SourceCodeLine = 419;
                        Functions.ClearBuffer ( TEMP7 ) ; 
                        __context__.SourceCodeLine = 420;
                        Functions.ClearBuffer ( TEMP8 ) ; 
                        __context__.SourceCodeLine = 421;
                        Functions.ClearBuffer ( TEMP9 ) ; 
                        __context__.SourceCodeLine = 422;
                        Functions.ClearBuffer ( TEMP10 ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 265;
                } 
            
            __context__.SourceCodeLine = 425;
            BFLAG2 = (ushort) ( 0 ) ; 
            } 
        
        else 
            { 
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
        
        __context__.SourceCodeLine = 444;
        ISENDNAME = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 445;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 446;
        STEMPMODULES  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 447;
        STEMPDEVICE  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 448;
        Functions.SetArray ( SCOMMAND , "" ) ; 
        __context__.SourceCodeLine = 449;
        Functions.SetArray ( SGET , "" ) ; 
        __context__.SourceCodeLine = 450;
        BOKTOSEND = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 451;
        BFLAG1 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 452;
        BFLAG2 = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    STEMPMODULES  = new CrestronString( InheritedStringEncoding, 100, this );
    STEMPDEVICE  = new CrestronString( InheritedStringEncoding, 100, this );
    STEMPDEVICECH  = new CrestronString( InheritedStringEncoding, 100, this );
    TEMP1  = new CrestronString( InheritedStringEncoding, 100, this );
    TEMP2  = new CrestronString( InheritedStringEncoding, 100, this );
    TEMP3  = new CrestronString( InheritedStringEncoding, 40, this );
    TEMP4  = new CrestronString( InheritedStringEncoding, 40, this );
    TEMP5  = new CrestronString( InheritedStringEncoding, 10, this );
    TEMP6  = new CrestronString( InheritedStringEncoding, 10, this );
    TEMP7  = new CrestronString( InheritedStringEncoding, 10, this );
    TEMP8  = new CrestronString( InheritedStringEncoding, 10, this );
    TEMP9  = new CrestronString( InheritedStringEncoding, 10, this );
    TEMP10  = new CrestronString( InheritedStringEncoding, 10, this );
    TRASH  = new CrestronString( InheritedStringEncoding, 40, this );
    SCOMMAND  = new CrestronString[ 501 ];
    for( uint i = 0; i < 501; i++ )
        SCOMMAND [i] = new CrestronString( InheritedStringEncoding, 100, this );
    SGET  = new CrestronString[ 501 ];
    for( uint i = 0; i < 501; i++ )
        SGET [i] = new CrestronString( InheritedStringEncoding, 100, this );
    SMODULEINSTANCEID  = new CrestronString[ 101 ];
    for( uint i = 0; i < 101; i++ )
        SMODULEINSTANCEID [i] = new CrestronString( InheritedStringEncoding, 100, this );
    
    SEND_NEXT = new Crestron.Logos.SplusObjects.DigitalInput( SEND_NEXT__DigitalInput__, this );
    m_DigitalInputList.Add( SEND_NEXT__DigitalInput__, SEND_NEXT );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    GET_NEXT_NAME = new Crestron.Logos.SplusObjects.DigitalInput( GET_NEXT_NAME__DigitalInput__, this );
    m_DigitalInputList.Add( GET_NEXT_NAME__DigitalInput__, GET_NEXT_NAME );
    
    TIMED_OUT = new Crestron.Logos.SplusObjects.DigitalOutput( TIMED_OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( TIMED_OUT__DigitalOutput__, TIMED_OUT );
    
    INITIALIZE_BUSY = new Crestron.Logos.SplusObjects.DigitalOutput( INITIALIZE_BUSY__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITIALIZE_BUSY__DigitalOutput__, INITIALIZE_BUSY );
    
    NAME_TIMED_OUT = new Crestron.Logos.SplusObjects.DigitalOutput( NAME_TIMED_OUT__DigitalOutput__, this );
    m_DigitalOutputList.Add( NAME_TIMED_OUT__DigitalOutput__, NAME_TIMED_OUT );
    
    DEVICE_TXD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DEVICE_TXD__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEVICE_TXD__DOLLAR____AnalogSerialOutput__, DEVICE_TXD__DOLLAR__ );
    
    CONTROL_ALIAS_RET = new Crestron.Logos.SplusObjects.StringOutput( CONTROL_ALIAS_RET__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONTROL_ALIAS_RET__AnalogSerialOutput__, CONTROL_ALIAS_RET );
    
    TO_MODULES = new InOutArray<StringOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TO_MODULES[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_MODULES__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_MODULES__AnalogSerialOutput__ + i, TO_MODULES[i+1] );
    }
    
    DEVICE_RXD__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( DEVICE_RXD__DOLLAR____AnalogSerialInput__, 5000, this );
    m_StringInputList.Add( DEVICE_RXD__DOLLAR____AnalogSerialInput__, DEVICE_RXD__DOLLAR__ );
    
    MODULES_RXD__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( MODULES_RXD__DOLLAR____AnalogSerialInput__, 5000, this );
    m_StringInputList.Add( MODULES_RXD__DOLLAR____AnalogSerialInput__, MODULES_RXD__DOLLAR__ );
    
    WTIMEOUT_Callback = new WaitFunction( WTIMEOUT_CallbackFn );
    WNAMETIMEOUT_Callback = new WaitFunction( WNAMETIMEOUT_CallbackFn );
    WWAKEUP_Callback = new WaitFunction( WWAKEUP_CallbackFn );
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    SEND_NEXT.OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_NEXT_OnPush_1, false ) );
    SEND_NEXT.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SEND_NEXT_OnRelease_2, false ) );
    GET_NEXT_NAME.OnDigitalPush.Add( new InputChangeHandlerWrapper( GET_NEXT_NAME_OnPush_3, false ) );
    MODULES_RXD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( MODULES_RXD__DOLLAR___OnChange_4, false ) );
    DEVICE_RXD__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DEVICE_RXD__DOLLAR___OnChange_5, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_YAMAHAMTX_PROCESSOR ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction WTIMEOUT_Callback;
private WaitFunction WNAMETIMEOUT_Callback;
private WaitFunction WWAKEUP_Callback;


const uint SEND_NEXT__DigitalInput__ = 0;
const uint INITIALIZE__DigitalInput__ = 1;
const uint GET_NEXT_NAME__DigitalInput__ = 2;
const uint DEVICE_RXD__DOLLAR____AnalogSerialInput__ = 0;
const uint MODULES_RXD__DOLLAR____AnalogSerialInput__ = 1;
const uint TIMED_OUT__DigitalOutput__ = 0;
const uint INITIALIZE_BUSY__DigitalOutput__ = 1;
const uint NAME_TIMED_OUT__DigitalOutput__ = 2;
const uint DEVICE_TXD__DOLLAR____AnalogSerialOutput__ = 0;
const uint CONTROL_ALIAS_RET__AnalogSerialOutput__ = 1;
const uint TO_MODULES__AnalogSerialOutput__ = 2;

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
