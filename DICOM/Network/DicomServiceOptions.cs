using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dicom.Network {
	/// <summary>
	/// Options to control the behavior of the <see cref="DicomService"/> base class.
	/// </summary>
	public class DicomServiceOptions {
		/// <summary>Default options for use with the <see cref="DicomService"/> base class.</summary>
		public readonly static DicomServiceOptions Default = new DicomServiceOptions();
		
		/// <summary>Constructor</summary>
		public DicomServiceOptions() {
			LogDataPDUs = false;
			LogDimseDatasets = false;
			MaxCommandBuffer = 1 * 1024;		//1KB
			MaxDataBuffer = 1 * 1024 * 1024;	//1MB
			ThreadPoolLinger = 200;
            MaximumPDULength = 16 * 1024;       //16KB
            DefaultEncoding = DicomEncoding.Default;
		}

		/// <summary>Write message to log for each P-Data-TF PDU sent or received.</summary>
		public bool LogDataPDUs {
			get;
			set;
		}

		/// <summary>Write command and data datasets to log.</summary>
		public bool LogDimseDatasets {
			get;
			set;
		}

		/// <summary>Maximum buffer length for command PDVs when generating P-Data-TF PDUs.</summary>
		public uint MaxCommandBuffer {
			get;
			set;
		}

		/// <summary>Maximum buffer length for data PDVs when generating P-Data-TF PDUs.</summary>
		public uint MaxDataBuffer {
			get;
			set;
		}

		/// <summary>Amount of time in milliseconds to retain Thread Pool thread to process additional requests.</summary>
		public int ThreadPoolLinger {
			get;
			set;
		}

        /// <summary>Maximum allowed PDU length. If a remote AE requests a longer PDU, the length is limited to this value</summary>
        public uint MaximumPDULength {
            get;
            set;
        }

        /// <summary>
        /// The encoding which is used to decode LO, LT, PN, SH, ST, UT datafields
        /// This encoding information will be used, if no information is given in the message itself (0008,0005)
        /// According to the standard, this should be the default encoding, but some crappy implementations send messages 
        /// in the local encoding without providing the correct information in (0008,0005)
        /// </summary>
        public Encoding DefaultEncoding {
            get;
            set;
        }

	}
}
