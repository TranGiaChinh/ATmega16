/*****************************************************
This program was produced by the
CodeWizardAVR V2.05.0 Professional
Automatic Program Generator
© Copyright 1998-2010 Pavel Haiduc, HP InfoTech s.r.l.
http://www.hpinfotech.com

Project : 
Version : 
Date    : 12/20/2023
Author  : NeVaDa
Company : 
Comments: 


Chip type               : ATmega16
Program type            : Application
AVR Core Clock frequency: 8.000000 MHz
Memory model            : Small
External RAM size       : 0
Data Stack size         : 256
*****************************************************/

#include <mega16.h>
#include <string.h>
#include <delay.h>
#include <stdio.h>
#define SW1_INT PIND.3;
#define ADC_VREF_TYPE 0x00
int i;
int l;
int time1=0xF0;
int time2=0xBD;
unsigned int chuc;
unsigned int dvi;
unsigned long nhietdo;
unsigned long ADC_out=0;
void uart_char_send(unsigned char chr){
    while (!(UCSRA & (1<<UDRE))) {};
            UDR=chr;
}
void uart_string_send (unsigned char *txt){
    unsigned char n,i;
    n=strlen(txt);
         for(i=0;i<n;i++){
         uart_char_send(txt[i]);}
}         
// External Interrupt 1 service routine
interrupt [EXT_INT1] void ext_int1_isr(void)
{
i+=1;
chuc=(i/10);
dvi=(i%10);
//uart_char_send('T');
uart_char_send(chuc+0x30);
uart_char_send(dvi+0x30);
//uart_char_send(10);
uart_char_send(13);
delay_ms(500);
}
interrupt [USART_RXC] void usart_rx_isr(void){
char data;
data=UDR;
//uart_char_send(data);
//dieukhien8LED
if (data=='1'){
    PORTC.0=0x01;  }
if (data=='a'){
    PORTC.0=0x00;  }
if (data=='2'){
    PORTC.1=0x01;  }
if (data=='b'){
    PORTC.1=0x00;  }
if (data=='3'){
    PORTC.2=0x01;  }
if (data=='c'){
    PORTC.2=0x00;  }
if (data=='4'){
    PORTC.3=0x01;  }
if (data=='d'){
    PORTC.3=0x00;  }
if (data=='5'){
    PORTC.4=0x01;  }
if (data=='e'){
    PORTC.4=0x00;  }
if (data=='6'){
    PORTC.5=0x01;  }
if (data=='f'){
    PORTC.5=0x00;  }
if (data=='7'){
    PORTC.6=0x01;  }
if (data=='g'){
    PORTC.6=0x00;  }
if (data=='8'){
    PORTC.7=0x01;  }
if (data=='h'){
    PORTC.7=0x00;  }
//dieukhiendenchithirun
if (data=='x'){
    l=0;}
if (data=='v'){
    l=1;}       
if (data=='q'){ 
    time1=0xF0;
    time2=0xBD;}
if (data=='w'){ 
    time1=0xE1;
    time2=0x7B;}
if (data=='r'){ 
    time1=0xD2;
    time2=0x39;}
if (data=='t'){ 
    time1=0xC2;
    time2=0xF6;}
if (data=='y'){ 
    time1=0xB3;
    time2=0xB4;}
if (data=='u'){ 
    time1=0xA4;
    time2=0x72;}
if (data=='i'){ 
    time1=0x95;
    time2=0x30;}
if (data=='o'){ 
    time1=0x85;
    time2=0xED;}
if (data=='p'){ 
    time1=0x76;
    time2=0xAB;}
if (data=='z'){ 
    time1=0x67;
    time2=0x69;}                                                                       
} 
// Declare your global variables here
// Read the AD conversion result
unsigned int read_adc(unsigned char adc_input)
{
ADMUX=adc_input | (ADC_VREF_TYPE & 0xff);
// Delay needed for the stabilization of the ADC input voltage
delay_us(10);
// Start the AD conversion
ADCSRA|=0x40;
// Wait for the AD conversion to complete
while ((ADCSRA & 0x10)==0);
ADCSRA|=0x10;
return ADCW;
}
interrupt [TIM1_OVF] void timer1_ovf_isr(void)
{  if(l==0){
   PORTB.1=0x00;}
   else{if(l==1){
   PORTB.1= ~PORTB.1;
   TCNT1H = time1;
   TCNT1L = time2;}}
     
}
void main(void)
{
// Declare your local variables here

// Input/Output Ports initialization
// Port A initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTA=0x00;
DDRA=0x00;

// Port B initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTB=0x00;
DDRB=0xFF;

// Port C initialization
// Func7=Out Func6=Out Func5=Out Func4=Out Func3=Out Func2=Out Func1=Out Func0=Out 
// State7=0 State6=0 State5=0 State4=0 State3=0 State2=0 State1=0 State0=0 
PORTC=0x00;
DDRC=0xFF;

// Port D initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTD=0x00;
DDRD=0x00;


// External Interrupt(s) initialization
// INT0: Off
// INT1: On
// INT1 Mode: Falling Edge
// INT2: Off
GICR|=0x80;
MCUCR=0x08;
MCUCSR=0x00;
GIFR=0x80;

TCCR1B=0x05;
// Timer(s)/Counter(s) Interrupt(s) initialization
TIMSK=0x04;
TCNT1H = time1; 
TCNT1L = time2;

// USART initialization
// Communication Parameters: 
//8 Data, 1 Stop, No Parity
// USART Receiver: On
// USART Transmitter: On
// USART Mode: Asynchronous
// USART Baud Rate: 9600
UCSRA=0x00;
UCSRC=0x86;
UCSRB=0x98; 
UBRRH=0x00;
UBRRL=0x33;

// Analog Comparator initialization
// Analog Comparator: Off
// Analog Comparator Input Capture by Timer/Counter 1: Off
ACSR=0x80;
SFIOR=0x00;

// ADC initialization
// ADC Clock frequency: 1000.000 kHz
// ADC Voltage Reference: AREF pin
// ADC Auto Trigger Source: ADC Stopped
ADMUX=ADC_VREF_TYPE & 0xff;
ADCSRA=0x83;
// SPI initialization
// SPI disabled
SPCR=0x00;

// TWI initialization
// TWI disabled
TWCR=0x00;

// Global enable interrupts
#asm("sei")

while (1)
      {
      ADC_out=read_adc(0);
      nhietdo=ADC_out*500/1023;
      
      chuc=(nhietdo/10);
      dvi=(nhietdo%10);
//    uart_string_send("nhiet do la:");
      uart_char_send(chuc+0x30);
      uart_char_send(dvi+0x30);
      uart_char_send(10);
      uart_char_send(13);
      delay_ms(200);
      
      }
}
