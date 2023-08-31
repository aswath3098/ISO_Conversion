using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_Conversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = "12345678919873";

            // Convert to ASCII
            byte[] asciiBytes = Encoding.ASCII.GetBytes(inputString);
            string asciiRep = string.Join(" ", asciiBytes);
            Console.WriteLine("ASCII Representation: " + asciiRep);

            // Convert to ASCII HEX
            string asciiHex = BitConverter.ToString(asciiBytes).Replace("-", "");
            Console.WriteLine("ASCII HEX Representation: " + asciiHex);

            // Convert to BCD
            byte[] bcdBytes = inputString.Select(c => (byte)(c - '0')).ToArray();
            string bcdRepresentation = string.Join(" ", bcdBytes.Select(b => Convert.ToString(b, 2).PadLeft(4, '0')));
            Console.WriteLine("BCD Representation: " + bcdRepresentation);
            // Convert to HEX
            string hexRepresentation = BitConverter.ToString(asciiBytes).Replace("-", "");
            Console.WriteLine("HEX Representation: " + hexRepresentation);

            // Convert the input number to EBCDIC
            Encoding ebcdicEncoding = Encoding.GetEncoding("IBM037");
            byte[] ebcdicBytes = ebcdicEncoding.GetBytes(inputString);
            string ebcdicString = ebcdicEncoding.GetString(ebcdicBytes);
            Console.WriteLine("EBCDIC Value: " + ebcdicString);

            // Convert to EBCDIC Binary
            string ebcdicBinaryRepresentation = string.Join(" ", ebcdicBytes.Select(b => Convert.ToString(b, 2)));
            Console.WriteLine("EBCDIC Binary Representation: " + ebcdicBinaryRepresentation);

            // Convert to EBCDIC HEX
            string ebcdicHexRepresentation = BitConverter.ToString(ebcdicBytes).Replace("-", "");
            Console.WriteLine("EBCDIC HEX Representation: " + ebcdicHexRepresentation);

            // Convert to Signed EBCDIC Numeric
            byte[] signedEBCDICNumericBytes = ebcdicBytes.Select(b => (byte)(b + 0x30)).ToArray();
            string signedEBCDICNumericRepresentation = BitConverter.ToString(signedEBCDICNumericBytes).Replace("-", "");
            Console.WriteLine("Signed EBCDIC Numeric Representation: " + signedEBCDICNumericRepresentation);

            // Convert to Binary-HEX
            string binaryHexRepresentation = BitConverter.ToString(asciiBytes).Replace("-", " ");
            Console.WriteLine("Binary-HEX Representation: " + binaryHexRepresentation);

            // Convert to BCH
            string bchRepresentation = BitConverter.ToString(asciiBytes).Replace("-", " ");
            Console.WriteLine("BCH Representation: " + bchRepresentation);

            Console.ReadLine();
        }
    }
}
