Imports System.Runtime.InteropServices.Marshal
Public Class Form1
#Region "NATIVE FUNCTIONS"
#Region "API"
    Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
    Private Declare Function DeviceIoControlNTFS Lib "kernel32" Alias "DeviceIoControl" (ByVal hDevice As Int32, ByVal dwIoControlCode As Int32, ByRef lpInBuffer As Object, ByVal nInBufferSize As Int32, ByRef lpOutBuffer As NTFS_VOLUME_DATA_BUFFER, ByVal nOutBufferSize As Int32, ByRef lpBytesReturned As Int32, ByVal lpOverlapped As Int32) As Int32
    Private Structure NTFS_VOLUME_DATA_BUFFER
        Dim VolumeSerialNumber As Int64
        Dim NumberSectors As Int64
        Dim TotalClusters As Int64
        Dim FreeClusters As Int64
        Dim TotalReserved As Int64
        Dim BytesPerSector As Int32 'UInt32
        Dim BytesPerCluster As Int32 'UInt32
        Dim BytesPerFileRecordSegment As Int32 'UInt32
        Dim ClustersPerFileRecordSegment As Int32 'UInt32
        Dim MftValidDataLength As Int64
        Dim MftStartLcn As Int64
        Dim Mft2StartLcn As Int64
        Dim MftZoneStart As Int64
        Dim MftZoneEnd As Int64
    End Structure
    Private Structure STANDARD_MFT_ENTRY
        Dim FileNumber As Int32 '0x00-0x03  FILE: For file clusters    BAAD: For bad clusters
        Dim UpdateSequenceOffset As Int16 '0x04-0x05
        Dim FixupArrayEntryCount As Int16 '0x06-0x07
        Dim LogfileSequenceNumber As Int64 '0x08-0x0F   $Logfile (LSN)
        Dim SequenceNumber As Int16 '0x10-0x11
        Dim HardLinkCount As Int16 '0x12-0x13
        Dim OffsetToFirstAttribute As Int16 '0x14-0x15
        Dim Flags As Int16 '0x16-0x17   0x01:Record in use  0x02:Directory (ACTUALLY 0x0000:DeletedFile 0x0100:File 0x0200:DeletedFolder 0x0300:Folder)
        Dim UsedEntrySize As Int32 '0x18-0x1B   How much of this mft entry is used
        Dim AllocatedEntrySize As Int32 '0x1C-0x1F   How much space this mft entry takes
        Dim FileReference As Int64 '0x20-0x27   File reference to the base of $FILE record
        Dim NextAttributeID As Int16 '0x28-0x29
        Dim AlignTo4BBoundary As Int16 '0x2A-0x2B  (XP and above)
        Dim MFTRecordNumber As Int32 '0x2C-0x2F  (XP and above)
        Dim Unused1 As Int64 '0x30-0x37
    End Structure
    Private Enum MFT_ENTRY_FILE_TYPE_FLAGS
        DeletedFile = 0
        File = 1
        DeletedDirectory = 2
        Directory = 3
        Stream = 9
        Metadata = 13
    End Enum
    Private Enum EFileAccess As System.Int32
        DELETE = &H10000
        READ_CONTROL = &H20000
        WRITE_DAC = &H40000
        WRITE_OWNER = &H80000
        SYNCHRONIZE = &H100000
        STANDARD_RIGHTS_REQUIRED = &HF0000
        STANDARD_RIGHTS_READ = READ_CONTROL
        STANDARD_RIGHTS_WRITE = READ_CONTROL
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL
        STANDARD_RIGHTS_ALL = &H1F0000
        SPECIFIC_RIGHTS_ALL = &HFFFF
        ACCESS_SYSTEM_SECURITY = &H1000000
        MAXIMUM_ALLOWED = &H2000000
        GENERIC_READ = &H80000000
        GENERIC_WRITE = &H40000000
        GENERIC_EXECUTE = &H20000000
        GENERIC_ALL = &H10000000
    End Enum
    Private Enum EFileShare
        FILE_SHARE_NONE = &H0
        FILE_SHARE_READ = &H1
        FILE_SHARE_WRITE = &H2
        FILE_SHARE_DELETE = &H4
    End Enum
    Private Enum ECreationDisposition
        CREATE_NEW = 1
        CREATE_ALWAYS = 2
        OPEN_EXISTING = 3
        OPEN_ALWAYS = 4
        TRUNCATE_EXISTING = 5
    End Enum
    Private Enum EFileAttributes
        FILE_ATTRIBUTE_READONLY = &H1
        FILE_ATTRIBUTE_HIDDEN = &H2
        FILE_ATTRIBUTE_SYSTEM = &H4
        FILE_ATTRIBUTE_DIRECTORY = &H10
        FILE_ATTRIBUTE_ARCHIVE = &H20
        FILE_ATTRIBUTE_DEVICE = &H40
        FILE_ATTRIBUTE_NORMAL = &H80
        FILE_ATTRIBUTE_TEMPORARY = &H100
        FILE_ATTRIBUTE_SPARSE_FILE = &H200
        FILE_ATTRIBUTE_REPARSE_POINT = &H400
        FILE_ATTRIBUTE_COMPRESSED = &H800
        FILE_ATTRIBUTE_OFFLINE = &H1000
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
        FILE_ATTRIBUTE_ENCRYPTED = &H4000
        FILE_ATTRIBUTE_VIRTUAL = &H10000
        FILE_FLAG_BACKUP_SEMANTICS = &H2000000
        FILE_FLAG_DELETE_ON_CLOSE = &H4000000
        FILE_FLAG_NO_BUFFERING = &H2000000
        FILE_FLAG_OPEN_NO_RECALL = &H100000
        FILE_FLAG_OPEN_REPARSE_POINT = &H200000
        FILE_FLAG_OVERLAPPED = &H40000000
        FILE_FLAG_POSIX_SEMANTICS = &H100000
        FILE_FLAG_RANDOM_ACCESS = &H10000000
        FILE_FLAG_SEQUENTIAL_SCAN = &H8000000
        FILE_FLAG_WRITE_THROUGH = &H80000000
    End Enum
    Private Enum FILE_DEVICE
        FILE_DEVICE_BEEP = 1
        FILE_DEVICE_CD_ROM
        FILE_DEVICE_CD_ROM_FILE_SYSTEM
        FILE_DEVICE_CONTROLLER
        FILE_DEVICE_DATALINK
        FILE_DEVICE_DFS
        FILE_DEVICE_DISK
        FILE_DEVICE_DISK_FILE_SYSTEM
        FILE_DEVICE_FILE_SYSTEM
        FILE_DEVICE_INPORT_PORT
        FILE_DEVICE_KEYBOARD
        FILE_DEVICE_MAILSLOT
        FILE_DEVICE_MIDI_IN
        FILE_DEVICE_MIDI_OUT
        FILE_DEVICE_MOUSE
        FILE_DEVICE_MULTI_UNC_PROVIDER
        FILE_DEVICE_NAMED_PIPE
        FILE_DEVICE_NETWORK
        FILE_DEVICE_NETWORK_BROWSER
        FILE_DEVICE_NETWORK_FILE_SYSTEM
        FILE_DEVICE_NULL
        FILE_DEVICE_PARALLEL_PORT
        FILE_DEVICE_PHYSICAL_NETCARD
        FILE_DEVICE_PRINTER
        FILE_DEVICE_SCANNER
        FILE_DEVICE_SERIAL_MOUSE_PORT
        FILE_DEVICE_SERIAL_PORT
        FILE_DEVICE_SCREEN
        FILE_DEVICE_SOUND
        FILE_DEVICE_DEVICE_STREAMS
        FILE_DEVICE_TAPE
        FILE_DEVICE_TAPE_FILE_SYSTEM
        FILE_DEVICE_TRANSPORT
        FILE_DEVICE_UNKNOWN
        FILE_DEVICE_VIDEO
        FILE_DEVICE_VIRTUAL_DISK
        FILE_DEVICE_WAVE_IN
        FILE_DEVICE_WAVE_OUT
        FILE_DEVICE_8042_PORT
        FILE_DEVICE_NETWORK_REDIRECTOR
        FILE_DEVICE_BATTERY
        FILE_DEVICE_BUS_EXTENDER
        FILE_DEVICE_MODEM
        FILE_DEVICE_VDM
        FILE_DEVICE_MASS_STORAGE
        FILE_DEVICE_SMB
        FILE_DEVICE_KS
        FILE_DEVICE_CHANGER
        FILE_DEVICE_SMARTCARD
        FILE_DEVICE_ACPI
        FILE_DEVICE_DVD
        FILE_DEVICE_FULLSCREEN_VIDEO
        FILE_DEVICE_DFS_FILE_SYSTEM
        FILE_DEVICE_DFS_VOLUME
    End Enum
    Private Const FILE_ANY_ACCESS = &H0
    Private Const FILE_READ_ACCESS = &H1
    Private Const FILE_WRITE_ACCESS = &H2
    Private Const METHOD_BUFFERED = &H0
    Private Const METHOD_IN_DIRECT = &H1
    Private Const METHOD_OUT_DIRECT = &H2
    Private Const METHOD_NEITHER = &H3
#End Region
#Region "FUNCTIONS"
    Private Function CTL_CODE(ByVal DeviceType As Int32, ByVal FunctionNumber As Int32, ByVal Method As Int32, ByVal Access As Int32) As Int32
        Return (DeviceType << 16) Or (Access << 14) Or (FunctionNumber << 2) Or Method
    End Function
    Private Function ByteArrayPart(ByVal Arrays() As Byte, ByVal LBound As Integer, ByVal UBound As Integer) As Byte()
        Dim temp(UBound - LBound + 1) As Byte
        Array.Copy(Arrays, LBound, temp, 0, UBound - LBound + 1)
        Return temp
    End Function
    Private Function GetFullPath2(ByVal ParentID As Integer, ByVal MFTBaseAddress As Long, ByVal MFTEntrySize As Integer, ByVal BytesPerCluster As Integer) As String
        If ParentID = 5 Then Return Strings.Left(ARKDDA.Disk, 2)
        Dim OrgMFTBA = MFTBaseAddress
        Dim Length As ULong = 0
        Dim LenLen As Byte = 0
        Dim Offset As ULong = 0
        Dim OffLen As Byte = 0
        Dim MFT() As Byte = ARKDDA.ReadSectors(MFTBaseAddress, MFTEntrySize)
        Dim baseaddrM = MergeToInt(MFT, &H14, &H15) 'The offset the the first attribute
        While MFT(baseaddrM) <> &H80
            baseaddrM = baseaddrM + MergeToInt(MFT, baseaddrM + &H4, baseaddrM + &H7) 'Add the length of the attribute to the base address to find the next attribute
        End While
        baseaddrM = baseaddrM + &H40
        While MFT(baseaddrM) > 0
            LenLen = MFT(baseaddrM) And &HF
            OffLen = (MFT(baseaddrM) And &HF0) / &H10
            Length = MergeToInt(MFT, baseaddrM + 1, baseaddrM + LenLen)
            Offset = Offset + MergeToInt(MFT, baseaddrM + 1 + LenLen, baseaddrM + LenLen + OffLen)
            If ((CLng(ParentID) * CLng(MFTEntrySize) * CLng(ARKDDA.BytesPerSector)) / CLng(BytesPerCluster)) > Length Then
                ParentID = ParentID - ((Length * CLng(BytesPerCluster)) \ (CLng(MFTEntrySize) * CLng(ARKDDA.BytesPerSector)))
            Else
                MFTBaseAddress = (Offset * CLng(BytesPerCluster)) \ CLng(ARKDDA.BytesPerSector)
                Exit While
            End If
            baseaddrM = baseaddrM + (1 + LenLen + OffLen)
        End While

        Dim Bytes() = ARKDDA.ReadSectors(MFTBaseAddress + CLng(ParentID * MFTEntrySize), 2)
        Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
        baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        Dim Parent = MergeToInt(Bytes, baseaddr + &H18, baseaddr + &H1D)
        Dim Name = System.Text.UnicodeEncoding.Unicode.GetString(ByteArrayPart(Bytes, baseaddr + &H5A, (baseaddr + &H5A) + ((2 * Bytes(baseaddr + &H58)) - 2)))
        baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        If Name.Contains("~") Then Name = System.Text.UnicodeEncoding.Unicode.GetString(ByteArrayPart(Bytes, baseaddr + &H5A, (baseaddr + &H5A) + ((2 * Bytes(baseaddr + &H58)) - 2)))
        If Name.Length >= 75 Then Name = "SKIPTHISFILE" 'Name = Mid(Name, 1, 74) & Mid(Name, 76, Name.Length - 75)
        'Name.Replace(Chr(0), "+")
        'Name = Mid(Name, 1, Len(Name) - 1)
        Name = Name.Trim(Chr(0))
        Return GetFullPath2(Parent, OrgMFTBA, MFTEntrySize, BytesPerCluster) & "\" & Name
    End Function
    Private Function MergeToInt(ByVal Array() As Byte, ByVal LBound As Integer, ByVal Ubound As Integer) As Int64
        Dim result As UInt64 = 0
        For action = 0 To Ubound - LBound
            'result = result + ((Array(Ubound - action)) << (action * 2))
            'result = result + ((Array(LBound + action)) << (action * 2))
            Try
                result = result + ((Array(LBound + action)) * (2 ^ (action * 8)))
            Catch
            End Try
            'result = result + ((Array(Ubound - action)) * (2 ^ (action * 8)))
        Next
        Try
            Return Convert.ToInt64(result)
        Catch
            Try
                Return Convert.ToInt64((result - Int64.MaxValue) - Int64.MaxValue)
            Catch
                Return 0
            End Try
        End Try
    End Function
    Private Function GetStringFromByteArray(ByVal Bytes() As Byte) As String
        Dim str As String = ""
        For Each part In Bytes
            str = str + ChrW(part)
        Next
        Return str
    End Function
    Public Function GetSizeStr(ByVal size As Long, Optional ByVal decimals As Integer = 0, Optional ByVal base As Long = 1024, Optional ByVal nodecimals As Boolean = False) As String
        Dim sz
        If decimals > 0 Then
            Dim sz2 As Double = CDbl(size)
            sz = sz2
        Else
            Dim sz2 As Long = size
            sz = sz2
        End If
        Dim units() As String = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "XB", "WB", "VB"}
        Dim unit As Integer = 0
redo:
        If sz >= base Then
            sz = sz / base
            unit = unit + 1
            If decimals > 0 Then sz = round(sz, decimals)
            GoTo redo
        End If
        If unit > UBound(units) Then Throw New Exception("Size too large.")
        If Not nodecimals Then
            Return sz.ToString & " " & units(unit)
        Else
            Return CInt(sz).ToString & " " & units(unit)
        End If
    End Function
    Public Function round(ByVal number As Double, ByVal decimals As Integer) As Double
        Return CDbl(CInt(number * (10 ^ decimals))) / CDbl(10 ^ decimals)
    End Function
    Dim DoEventsCounter As ULong = 0
    Public Function GetFileIntegrity(ByVal MFTSector As ULong, ByVal BytesPerSector As Integer, ByVal BytesPerFileRecordSegment As Integer) As String
        Dim Bytes = ARKDDA.ReadSectors(MFTSector, (BytesPerFileRecordSegment / BytesPerSector))
        Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
        While Bytes(baseaddr) <> &H80
            baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        End While
        Dim Length As ULong = 0
        Dim LenLen As Byte = 0
        Dim Offset As ULong = 0
        Dim OffLen As Byte = 0
        Dim FileSize As ULong = 0
        Dim GoodClusters As ULong = 0
        DoEventsCounter = 0
        If MergeToInt(Bytes, baseaddr + &HE, baseaddr + &HF) = 1 Then
            Return "Excellent"
        End If
        baseaddr = baseaddr + &H40
        While Bytes(baseaddr) > 0
            LenLen = Bytes(baseaddr) And &HF
            OffLen = (Bytes(baseaddr) And &HF0) / &H10
            Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
            Offset = Offset + MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
            FileSize = FileSize + Length
            If Length > 2 ^ 20 Then Length = 1
            For Check = Offset To Offset + Length - 1
                If Not GetBitmapClusterAllocation(Check) Then GoodClusters = GoodClusters + 1
                DoEventsCounter = DoEventsCounter + 1
                If DoEventsCounter >= 100000 Then
                    Application.DoEvents()
                    DoEventsCounter = 0
                End If
            Next
            baseaddr = baseaddr + (1 + LenLen + OffLen)
        End While
        Dim Percent = (GoodClusters * 100) \ FileSize
        If Percent = 100 Then Return "Excellent"
        If Percent >= 80 And Percent <= 99 Then Return "Good"
        If Percent >= 60 And Percent <= 79 Then Return "OK"
        If Percent >= 40 And Percent <= 59 Then Return "Bad"
        If Percent >= 1 And Percent >= 39 Then Return "Horrible"
        If Percent = 0 Then Return "Overwritten"
        Return "Unknown"
    End Function
    Private Function GetBitmapClusterAllocation(ByVal Cluster As ULong) As Boolean
        Return ((Bitmap(Cluster \ 8) And (2 ^ (Cluster Mod 8))) / (2 ^ (Cluster Mod 8))) = 1
    End Function
    Private Function ReadBitmap(ByVal Drive As String) As Byte()
        Dim RBM As DirectDriveIO 'New DirectDriveIO(Drive)
        Drive = Drive.TrimEnd("\")
        Try
            RBM = New DirectDriveIO(Drive & "\")
        Catch
            MsgBox("Could not open drive.", MsgBoxStyle.Critical, "ERROR")
            Exit Function
        End Try
        Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
        If diskhandle = 0 Then
            diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            If diskhandle = 0 Then
                MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
                Exit Function
            End If
        End If
        Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
        Dim buffer As NTFS_VOLUME_DATA_BUFFER
        DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
        CloseHandle(diskhandle)
        Dim MFTAddress As Long = buffer.MftStartLcn * CLng(buffer.BytesPerCluster / buffer.BytesPerSector)
        Dim MFTEntrySize As Integer = buffer.BytesPerFileRecordSegment / buffer.BytesPerSector
        Dim BitmapBase As Long = MFTAddress + (MFTEntrySize * 6)
        Dim Bytes = RBM.ReadSectors(BitmapBase, MFTEntrySize)
        Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
        baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        'baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        'Read the data runs 0x40
        baseaddr = baseaddr + &H40
        Dim Length As ULong = 0
        Dim LenLen As Byte = 0
        Dim Offset As ULong = 0
        Dim OffLen As Byte = 0
        Dim TempBytes() As Byte
        Dim BitmapBytes() As Byte
        LenLen = Bytes(baseaddr) And &HF
        OffLen = (Bytes(baseaddr) And &HF0) / &H10
        Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
        Offset = MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
        BitmapBytes = RBM.ReadSectors(Offset * (buffer.BytesPerCluster / buffer.BytesPerSector), Length * (buffer.BytesPerCluster / buffer.BytesPerSector))
        baseaddr = baseaddr + (1 + LenLen + OffLen)
        While Bytes(baseaddr) > 0
            LenLen = Bytes(baseaddr) And &HF
            OffLen = (Bytes(baseaddr) And &HF0) / &H10
            Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
            Offset = Offset + MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
            TempBytes = RBM.ReadSectors(Offset * (buffer.BytesPerCluster / buffer.BytesPerSector), Length * (buffer.BytesPerCluster / buffer.BytesPerSector))
            BitmapBytes = MergeByteArrays(BitmapBytes, TempBytes)
            baseaddr = baseaddr + (1 + LenLen + OffLen)
        End While
        Return BitmapBytes
    End Function
    Private Function MergeByteArrays(ByVal a As Byte(), ByVal b As Byte()) As Byte()
        Dim c(a.Count + b.Count - 1) As Byte
        For aa = 0 To UBound(a)
            c(aa) = a(aa)
        Next
        For ab = UBound(a) + 1 To UBound(c)
            c(ab) = b(ab - (UBound(a) + 1))
        Next
        Return c
    End Function
    Private Function ByteArrayToBitArray(ByVal ByteArray As Byte()) As BitArray
        Dim BitA As New BitArray(ByteArray.Count * 8)
        Dim Counter As ULong = 0
        For Each b In ByteArray
            For c = 0 To 7
                BitA(Counter + c) = (b And (2 ^ c)) / (2 ^ c)
            Next c
            Counter = Counter + 8
        Next
        Return BitA
    End Function
    Public Function GetImageFormat(ByVal Img As Image) As String
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) Then Return "BMP"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf) Then Return "EMF"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif) Then Return "EXIF"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif) Then Return "GIF"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon) Then Return "ICON"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) Then Return "JPEG"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp) Then Return "MEMORYBMP"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) Then Return "PNG"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) Then Return "TIFF"
        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf) Then Return "WMF"
        Return "UNKNOWN"
    End Function
    Public Function RemoveBadChars(ByVal Str As String) As String
        For rep = 0 To 31
            'Str.Replace(Chr(rep), "")
            If rep <> 9 And rep <> 10 And rep <> 13 Then Str = Str.Replace(Chr(rep), "")
        Next
        Str = Str.Replace(Chr(127), "")
        'Str.Replace(Chr(129), "")
        'Str.Replace(Chr(141), "")
        'Str.Replace(Chr(143), "")
        'Str.Replace(Chr(144), "")
        'Str.Replace(Chr(157), "")
        Return Str
    End Function
#End Region
#End Region
    Public Structure NonResidentData
        Dim AttributeType As Int32 '0x00            Attribute Type Identifier
        Dim AttributeLength As Int32 '0x04          Size of the attribute structure
        Dim NonResidentFlag As Byte '0x08           Non resident data flag
        Dim NameLength As Byte '0x09                Length of attribute name
        Dim OffsetToName As UInt16 '0x0A            Offset to attribute name
        Dim Flags As UInt16 '0x0C                   Attribute Flags
        Dim AttributeId As UInt16 '0x0E             Attribute Identifier
        Dim StartingVCN As UInt64 '0x10             First cluster of file
        Dim LastVCN As UInt64 '0x18                 Last cluster of file
        Dim DataRunOffset As UInt16 '0x20           Offset to data runs
        Dim CompressionSizeUnit As UInt16 '0x22     ?
        Dim Padding As Int32 '0x24                  Padding
        Dim AttributeSize As UInt64 '0x28           File Size
        Dim RealAttributeSize As UInt64 '0x30       Allocated file size
        Dim InitialisedStreamSize As UInt64 '0x38   Allocated file size
    End Structure
    'JPEGS start with FF D8 FF E0 00 10 4A 46 49 46 and end with FF D9
    Dim JPEGSTART() As Byte = {&HFF, &HD8, &HFF, &HE0, &H0, &H10, &H4A, &H46, &H49, &H46}
    Dim JPEGEND() As Byte = {&HFF, &HD9}
    Dim JPEGENDSTR As String = System.Text.UTF8Encoding.UTF8.GetString(JPEGEND)
    'BMPS start with 42 4D ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? where 0x02-0x05 is the bitmap size in bytes
    'PNGS start with 89 50 4E 47 0D 0A 1A 0A and end with 49 45 4E 44 AE 42 60 82
    'GIFS start with 47 49 46 38 39 61 and end with 00 3B
    'SWFS start with "CWS"
    Dim ARKDDA As DirectDriveIO
    Dim LastDrive As String
    Dim Bitmap() As Byte
    Dim Preveiw As ULong = ULong.MinValue
    Public Sub FindHDFiles(ByVal Drive As String)
        Drive = Drive.TrimEnd("\")
        Try
            Dim dinfo = My.Computer.FileSystem.GetDriveInfo(Drive & "\")
            If Not dinfo.IsReady Then
                MsgBox("Drive not ready.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            If dinfo.DriveFormat <> "NTFS" Then
                MsgBox("This feature only works on NTFS volumes.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            ARKDDA = New DirectDriveIO(Drive & "\")
        Catch
            MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End Try
        Drive = Drive.TrimEnd("\")
        Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
        If diskhandle = 0 Then
            diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            If diskhandle = 0 Then
                MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
        End If
        Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
        Dim buffer As NTFS_VOLUME_DATA_BUFFER
        DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
        CloseHandle(diskhandle)
        Dim MFTAddress As Long = buffer.MftStartLcn * CLng(buffer.BytesPerCluster / buffer.BytesPerSector)
        Dim MFTEntrySize As Integer = buffer.BytesPerFileRecordSegment / buffer.BytesPerSector
        Dim NumberOfEntries As Long = buffer.MftValidDataLength / MFTEntrySize
        Dim Bytes(buffer.BytesPerCluster) As Byte
        Dim CurrEntryBytes(MFTEntrySize * buffer.BytesPerSector) As Byte
        Dim CurrEntry As New STANDARD_MFT_ENTRY
        Dim Type As Byte
        Dim Name As String
        Dim BaseAddr As Long
        Dim Parent As Integer
        Dim DoEventsCounter As Integer = 0
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = buffer.MftValidDataLength / buffer.BytesPerFileRecordSegment
        ToolStripStatusLabel1.Text = "Finding files in " & Drive & "\..."
        Button1.Enabled = False
        Button2.Enabled = False
        ComboBox1.Enabled = False
        Button3.Enabled = False
        CheckBox2.Enabled = False
        LastDrive = Drive
        If CheckBox2.Checked Then Bitmap = ReadBitmap(Drive)
        Dim BitmapBase As Long = MFTAddress + (MFTEntrySize * 0)
        Bytes = ARKDDA.ReadSectors(BitmapBase, MFTEntrySize)
        BaseAddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
        While Bytes(baseaddr) <> &H80
            baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
        End While
        baseaddr = baseaddr + &H40
        Dim Length As ULong = 0
        Dim LenLen As Byte = 0
        Dim Offset As ULong = 0
        Dim OffLen As Byte = 0
        Dim Path As String = ""
        Dim BaseAddr2 As ULong = 0
        Dim FileSize As ULong = 0
        Dim LoopCount As Integer = 0
        Dim PartNum As Integer = 0
        While Bytes(baseaddr) > 0
            LenLen = Bytes(BaseAddr) And &HF
            OffLen = (Bytes(BaseAddr) And &HF0) / &H10
            Length = MergeToInt(Bytes, BaseAddr + 1, BaseAddr + LenLen)
            Offset = Offset + MergeToInt(Bytes, BaseAddr + 1 + LenLen, BaseAddr + LenLen + OffLen)
            For Record = 0 To ((Length * buffer.BytesPerCluster) / buffer.BytesPerFileRecordSegment) - 1
                DoEventsCounter = DoEventsCounter + 1
                If DoEventsCounter >= 100 Then
                    Application.DoEvents()
                    DoEventsCounter = 0
                End If
                Try
                    If (PartNum + 1) >= (CurrEntryBytes.Count / buffer.BytesPerFileRecordSegment) Then
                        CurrEntryBytes = ARKDDA.ReadSectors((Record * MFTEntrySize) + (Offset * (buffer.BytesPerCluster / buffer.BytesPerSector)), MFTEntrySize * 1024)
                        BaseAddr2 = 0
                        PartNum = 0
                    Else
                        'CurrEntryBytes = ByteArrayPart(CurrEntryBytes, buffer.BytesPerFileRecordSegment, UBound(CurrEntryBytes))
                        'BaseAddr2 = (((BaseAddr2 \ buffer.BytesPerFileRecordSegment) + 1) * buffer.BytesPerFileRecordSegment)
                        PartNum = PartNum + 1
                        BaseAddr2 = PartNum * buffer.BytesPerFileRecordSegment
                    End If
                    If CurrEntryBytes(BaseAddr2) <> Asc("F") Then
                        'If CurrEntryBytes(0) <> Asc("F") Then
                        GoTo dn
                    End If
                    Name = ""
                    Parent = 5

                    Path = ""
                    FileSize = 0
                    'Type = CurrEntryBytes(&H16)
                    Type = CurrEntryBytes(&H16 + BaseAddr2)
                    'If Type = MFT_ENTRY_FILE_TYPE_FLAGS.DeletedDirectory Or Type = MFT_ENTRY_FILE_TYPE_FLAGS.DeletedFile Then
                    If Type = MFT_ENTRY_FILE_TYPE_FLAGS.DeletedFile Then
                        'BaseAddr2 = BaseAddr2 + MergeToInt(CurrEntryBytes, &H14, &H15) 'The offset the the first attribute
                        BaseAddr2 = BaseAddr2 + MergeToInt(CurrEntryBytes, BaseAddr2 + &H14, BaseAddr2 + &H15) 'The offset the the first attribute
                        BaseAddr2 = BaseAddr2 + MergeToInt(CurrEntryBytes, BaseAddr2 + &H4, BaseAddr2 + &H7) 'Add the length of the attribute to the base address to find the next attribute
                        Try
                            Parent = MergeToInt(CurrEntryBytes, BaseAddr2 + &H18, BaseAddr2 + &H1D)
                        Catch
                        End Try
                        Try
                            If FileSize = 0 Then FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H48, BaseAddr2 + &H4F)
                            If FileSize > 2 ^ 30 Then FileSize = 0
                            'If FileSize = 0 Then FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H40, BaseAddr2 + &H47)
                        Catch
                        End Try
                        Try
                            Name = System.Text.UnicodeEncoding.Unicode.GetString(ByteArrayPart(CurrEntryBytes, BaseAddr2 + &H5A, (BaseAddr2 + &H5A) + ((2 * CurrEntryBytes(BaseAddr2 + &H58)) - 2)))
                        Catch
                        End Try
                        Try
                            If Name.Contains("~") Then
                                BaseAddr2 = BaseAddr2 + MergeToInt(CurrEntryBytes, BaseAddr2 + &H4, BaseAddr2 + &H7) 'Add the length of the attribute to the base address to find the next attribute
                                If FileSize = 0 Then FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H48, BaseAddr2 + &H4F)
                                If FileSize > 2 ^ 30 Then FileSize = 0
                                'If FileSize = 0 Then FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H40, BaseAddr2 + &H47)
                                Name = System.Text.UnicodeEncoding.Unicode.GetString(ByteArrayPart(CurrEntryBytes, BaseAddr2 + &H5A, (BaseAddr2 + &H5A) + ((2 * CurrEntryBytes(BaseAddr2 + &H58)) - 2)))
                            End If
                        Catch
                        End Try
                        If Name.Length >= 75 Then Name = Mid(Name, 1, 74) & Mid(Name, 76, Name.Length - 75)
                        If CheckBox1.Checked Then
                            Try
                                Path = GetFullPath2(Parent, MFTAddress, MFTEntrySize, buffer.BytesPerCluster) & "\" & Name
                            Catch
                            End Try
                        End If
                        If FileSize = 0 Then
                            Try
                                LoopCount = 0
                                While CurrEntryBytes(BaseAddr2) <> &H80 And LoopCount < 5
                                    LoopCount = LoopCount + 1
                                    BaseAddr2 = BaseAddr2 + MergeToInt(CurrEntryBytes, BaseAddr2 + &H4, BaseAddr2 + &H7) 'Add the length of the attribute to the base address to find the next attribute
                                End While
                                'FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H28, BaseAddr2 + &H2F)
                                'If FileSize > 2 ^ 30 Then FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H38, BaseAddr2 + &H3F)
                                If MergeToInt(CurrEntryBytes, BaseAddr2 + &HE, BaseAddr2 + &HF) = 1 Then
                                    'It is recycled (filename at offset 0x30,file size at offset 0x10)
                                    FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H10, BaseAddr2 + &H13)
                                    'Path = ""
                                    'BaseAddr2 = BaseAddr2 + &H30
                                    'While CurrEntryBytes(BaseAddr2) > 0
                                    'Path = Path + ChrW(MergeToInt(CurrEntryBytes, BaseAddr2, BaseAddr2 + 1))
                                    'Path = Path + ChrW(CurrEntryBytes(BaseAddr2))
                                    'BaseAddr2 = BaseAddr2 + 2
                                    'End While
                                Else
                                    'FileSize = 0
                                    FileSize = MergeToInt(CurrEntryBytes, BaseAddr2 + &H30, BaseAddr2 + &H37)
                                End If
                                If FileSize > 2 ^ 30 Then FileSize = 0
                            Catch
                            End Try
                        End If
                        If FileSize > 0 Then
                            With ListView1.Items.Add(Name)
                                If Not Path.Contains("SKIPTHISFILE") Then
                                    .SubItems.Add(Path)
                                Else
                                    .SubItems.Add("")
                                End If
                                .SubItems.Add(FileSize)
                                .SubItems.Add((Record * MFTEntrySize) + (Offset * (buffer.BytesPerCluster / buffer.BytesPerSector)))
                                If CheckBox2.Checked Then
                                    Try
                                        .SubItems.Add(GetFileIntegrity((Record * MFTEntrySize) + (Offset * (buffer.BytesPerCluster / buffer.BytesPerSector)), buffer.BytesPerSector, buffer.BytesPerFileRecordSegment))
                                    Catch
                                        .SubItems.Add("Unknown")
                                    End Try
                                Else
                                    .SubItems.Add("")
                                End If
                                ListView2.Items.Add(.Clone)
                            End With
                        End If
                        GoTo dn
                    End If
                Catch
                End Try
dn:
                Try
                    ProgressBar1.Value = ProgressBar1.Value + 1
                Catch
                End Try
            Next Record
            BaseAddr = BaseAddr + (1 + LenLen + OffLen)
        End While
        ProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = ""
        Button1.Enabled = True
        Button2.Enabled = True
        ComboBox1.Enabled = True
        Button3.Enabled = True
        CheckBox2.Enabled = True
    End Sub

    Public Sub DeepFindFiles(ByVal Drive As String)
        Try
            Dim DDA As New DirectDriveIO(Drive.TrimEnd("\"))
            Dim Sector As ULong = 0
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = 1000
            Dim TempStart() As Byte
            Dim FileStart() As Byte
            Dim FileSize As ULong = 0
            Dim BaseSize As ULong = 0
            Dim Start As Integer = 0
            Dim Iteration As Integer = 16
            ListView1.Items.Clear()
            ListView2.Items.Clear()
            While Sector < DDA.LastSector
                If Iteration > 15 Then
                    FileStart = DDA.ReadSectors(Sector, 16)
                    Iteration = 0
                Else
                    Iteration = Iteration + 1
                End If
                'FileStart = DDA.ReadSectors(Sector, 1)
                If ByteArrayPart(FileStart, (Iteration * DDA.BytesPerSector) + 0, (Iteration * DDA.BytesPerSector) + 9) Is JPEGSTART Then
                    BaseSize = 0
                    FileStart = DDA.ReadSectors(Sector + BaseSize, 1)
                    While Not System.Text.UTF8Encoding.UTF8.GetString(FileStart).Contains(JPEGENDSTR)
                        BaseSize = BaseSize + 1
                        FileStart = DDA.ReadSectors(Sector + BaseSize, 1)
                    End While
                    FileSize = (BaseSize * DDA.BytesPerSector) + System.Text.UTF8Encoding.UTF8.GetString(FileStart).IndexOf(JPEGENDSTR)
                    'Find file size
                    With ListView1.Items.Add("=JPEG FILE=")
                        .SubItems.Add(Sector)
                        .SubItems.Add(FileSize)
                        .SubItems.Add("-1")
                        .SubItems.Add("")
                        ListView2.Items.Add(.Clone)
                    End With
                End If
                Try
                    ProgressBar1.Value = Sector \ (DDA.LastSector / 1000)
                Catch
                End Try
                Application.DoEvents()
                Sector = Sector + 1
            End While
        Catch
        End Try
    End Sub

    Public Sub RecoverSingleFile()
        If Not SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim Errors As Boolean = False
        Try
            Dim Drive = LastDrive
            Dim MFTSector = ListView1.SelectedItems(0).SubItems(3).Text
            Dim FileLength As ULong = ListView1.SelectedItems(0).SubItems(2).Text
            Dim RBM As DirectDriveIO 'New DirectDriveIO(Drive)
            Drive = Drive.TrimEnd("\")
            Try
                RBM = New DirectDriveIO(Drive & "\")
            Catch
                MsgBox("Could not open drive.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End Try
            Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            If diskhandle = 0 Then
                diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
                If diskhandle = 0 Then
                    MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
                    Exit Sub
                End If
            End If
            Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
            Dim buffer As NTFS_VOLUME_DATA_BUFFER
            DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
            CloseHandle(diskhandle)
            Dim Bytes = RBM.ReadSectors(MFTSector, (buffer.BytesPerFileRecordSegment / buffer.BytesPerSector))
            Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
            While Bytes(baseaddr) <> &H80
                baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
            End While
            baseaddr = baseaddr + &H40
            Dim Length As ULong = 0
            Dim LenLen As Byte = 0
            Dim Offset As ULong = 0
            Dim OffLen As Byte = 0
            Dim ReadSize As ULong = 0
            Dim TempFile As New System.IO.FileStream(SaveFileDialog1.FileName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
            While Bytes(baseaddr) > 0
                LenLen = Bytes(baseaddr) And &HF
                OffLen = (Bytes(baseaddr) And &HF0) / &H10
                Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
                Offset = Offset + MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
                TempFile.Write(RBM.ReadSectors(Offset * (buffer.BytesPerCluster / buffer.BytesPerSector), Length * (buffer.BytesPerCluster / buffer.BytesPerSector)), 0, Length * buffer.BytesPerCluster)
                ReadSize = ReadSize + Length
                ToolStripStatusLabel1.Text = "Recovering file " & round((ReadSize * buffer.BytesPerCluster * 100) / FileLength, 1) & "%..."
                baseaddr = baseaddr + (1 + LenLen + OffLen)
            End While
            TempFile.SetLength(FileLength)
            TempFile.Close()
            TempFile.Dispose()
            MsgBox("File recovered successfuly.", MsgBoxStyle.Information, "")
        Catch
            MsgBox("File not recovered.", MsgBoxStyle.Critical, "ERROR")
        End Try
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindHDFiles(Strings.Left(ComboBox1.SelectedItem, 3))
        'DeepFindFiles(Strings.Left(ComboBox1.SelectedItem, 3))
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Preveiw = Preveiw + 1
        If Preveiw >= ULong.MaxValue - 1 Then Preveiw = ULong.MinValue
        Dim ThisPreveiw = Preveiw
        Try
            'If ListView1.SelectedItems(0).Text.Contains(".jpg") Or ListView1.SelectedItems(0).Text.Contains(".gif") Or ListView1.SelectedItems(0).Text.Contains(".png") Or ListView1.SelectedItems(0).Text.Contains(".tiff") Or ListView1.SelectedItems(0).Text.Contains(".jpeg") Or ListView1.SelectedItems(0).Text.Contains(".bmp") Then
            If ULong.Parse(ListView1.SelectedItems(0).SubItems(2).Text) < 2 ^ 22 Then
                Try
                    Dim Drive = LastDrive
                    'Dim Drive = Strings.Left(ComboBox1.SelectedText, 2)
                    Dim MFTSector = ListView1.SelectedItems(0).SubItems(3).Text
                    Dim FileLength = ListView1.SelectedItems(0).SubItems(2).Text
                    Dim RBM As DirectDriveIO 'New DirectDriveIO(Drive)
                    Drive = Drive.TrimEnd("\")
                    Try
                        RBM = New DirectDriveIO(Drive & "\")
                    Catch
                        Exit Sub
                    End Try
                    Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
                    If diskhandle = 0 Then
                        diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
                        If diskhandle = 0 Then
                            Exit Sub
                        End If
                    End If
                    Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
                    Dim buffer As NTFS_VOLUME_DATA_BUFFER
                    DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
                    CloseHandle(diskhandle)
                    Dim Bytes = RBM.ReadSectors(MFTSector, (buffer.BytesPerFileRecordSegment / buffer.BytesPerSector))
                    Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
                    While Bytes(baseaddr) <> &H80
                        baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
                    End While

                    Dim Length As ULong = 0
                    Dim LenLen As Byte = 0
                    Dim Offset As ULong = 0
                    Dim OffLen As Byte = 0
                    'Dim ReadSize As ULong = 0
                    Dim TempFile As New System.IO.MemoryStream
                    'ToolStripStatusLabel1.Text = "Reading File..."
                    If MergeToInt(Bytes, baseaddr + &HE, baseaddr + &HF) = 1 And (buffer.BytesPerFileRecordSegment - (baseaddr + &H18 + FileLength)) > 0 Then
                        Try
                            TempFile.Write(ByteArrayPart(Bytes, baseaddr + &H18, baseaddr + &H18 + FileLength), 0, FileLength)
                        Catch
                        End Try
                        GoTo CleanUp
                    End If
                    baseaddr = baseaddr + &H40
                    While Bytes(baseaddr) > 0
                        LenLen = Bytes(baseaddr) And &HF
                        OffLen = (Bytes(baseaddr) And &HF0) / &H10
                        Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
                        Offset = Offset + MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
                        TempFile.Write(RBM.ReadSectors(Offset * (buffer.BytesPerCluster / buffer.BytesPerSector), Length * (buffer.BytesPerCluster / buffer.BytesPerSector)), 0, Length * buffer.BytesPerCluster)
                        If TempFile.Length > FileLength Then Exit While
                        'ReadSize = ReadSize + Length
                        'ToolStripStatusLabel1.Text = "Reading file " & ListView1.SelectedItems(0).Text & " " & round((ReadSize * buffer.BytesPerCluster * 100) / FileLength, 1) & "%..."
                        baseaddr = baseaddr + (1 + LenLen + OffLen)
                        Application.DoEvents()
                    End While
CleanUp:
                    Application.DoEvents()
                    TempFile.SetLength(FileLength)
                    Application.DoEvents()
                    Try
                        Dim Img As Bitmap
                        Try
                            Img = Image.FromStream(TempFile, False, True)
                            Application.DoEvents()
                        Catch
                            Img = Image.FromStream(TempFile, False, False)
                            Application.DoEvents()
                            Img = Img.GetThumbnailImage(Img.Width, Img.Height, Nothing, 0)
                            Application.DoEvents()
                        End Try
                        'Img.SaveAdd
                        'Me.Text = GetImageFormat(Img)
                        If Img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif) Then Img = Img.GetThumbnailImage(Img.Width, Img.Height, Nothing, 0)
                        Application.DoEvents()
                        Img.SetResolution(300, 300)
                        'If Img.Width > 1000 Then
                        'Img = Img.GetThumbnailImage(1000, Img.Height / (Img.Width / 1000), Nothing, 0)
                        'End If
                        'If Img.Height > 1000 Then
                        'Img = Img.GetThumbnailImage(Img.Width / (Img.Height / 1000), 1000, Nothing, 0)
                        'End If
                        If ThisPreveiw = Preveiw Then
                            Try
                                PictureBox1.Image = Img
                            Catch
                            End Try
                            Application.DoEvents()
                            'Img.SelectActiveFrame(New System.Drawing.Imaging.FrameDimension(Img.FrameDimensionsList(0)), 0)
                            'PictureBox1.Image = Image.FromStream(TempFile, False, True)
                            PictureBox1.Show()
                            TextBox1.Hide()
                            Application.DoEvents()
                        End If
                    Catch
                        'PictureBox1.Image = PictureBox1.ErrorImage
                        TempFile.Seek(0, IO.SeekOrigin.Begin)
                        Dim Data(TempFile.Length - 1) As Byte
                        Application.DoEvents()
                        TempFile.Read(Data, 0, TempFile.Length)
                        'Application.DoEvents()
                        'TextBox1.Text = Convert.ToBase64String(Data)
                        Application.DoEvents()
                        'TextBox1.Text = System.Text.ASCIIEncoding.ASCII.GetString(Data).Replace(Chr(0), "")
                        If ThisPreveiw = Preveiw Then
                            TextBox1.Text = RemoveBadChars(System.Text.ASCIIEncoding.ASCII.GetString(Data))
                            Application.DoEvents()
                            TextBox1.Show()
                            PictureBox1.Hide()
                            Application.DoEvents()
                        End If
                    End Try
                    TempFile.Close()
                    TempFile.Dispose()
                    Application.DoEvents()
                    'My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\temp.jpg", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Catch
                End Try
            Else
                If ThisPreveiw = Preveiw Then
                    TextBox1.Text = "File too large to preview."
                    TextBox1.Show()
                    PictureBox1.Hide()
                    Application.DoEvents()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        RefreshDrives()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshDrives()
    End Sub

    Public Sub RefreshDrives()
        ComboBox1.Items.Clear()
        For Each Drive In My.Computer.FileSystem.Drives
            Try
                If Drive.DriveFormat = "NTFS" Then ComboBox1.Items.Add(Drive.Name & " (" & GetSizeStr(Drive.TotalSize) & " " & Drive.DriveFormat & ")")
            Catch
            End Try
        Next
        Try
            ComboBox1.SelectedIndex = 0
        Catch
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Dir As String = ""
        Dim AddOn As String = ""
        Dim AddOnNum As ULong = 0
        Dim Errors As Boolean = False
        Dim RBM As DirectDriveIO 'New DirectDriveIO(Drive)
        Dim buffer As NTFS_VOLUME_DATA_BUFFER
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dir = FolderBrowserDialog1.SelectedPath
            If Not My.Computer.FileSystem.DirectoryExists(Dir) Then My.Computer.FileSystem.CreateDirectory(Dir)
        Else
            Exit Sub
        End If
        Try
            Dim Drive = LastDrive
            Drive = Drive.TrimEnd("\")
            Try
                RBM = New DirectDriveIO(Drive & "\")
            Catch
                MsgBox("Could not open drive.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End Try
            Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            If diskhandle = 0 Then
                diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
                If diskhandle = 0 Then
                    MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
                    Exit Sub
                    'GoTo DoNext
                End If
            End If
            Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
            DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
            CloseHandle(diskhandle)
        Catch ex As Exception
            MsgBox("Could not access drive.", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End Try
        Dim ItemCol = ListView1.CheckedItems
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = ItemCol.Count
        Dim Num As ULong = 0
        For Each Item As ListViewItem In ItemCol
            ProgressBar1.Value = Num
            Num = Num + 1
            Try
                Dim MFTSector = Item.SubItems(3).Text
                Dim FileLength As ULong = Item.SubItems(2).Text
                Dim Bytes = RBM.ReadSectors(MFTSector, (buffer.BytesPerFileRecordSegment / buffer.BytesPerSector))
                Dim baseaddr = MergeToInt(Bytes, &H14, &H15) 'The offset the the first attribute
                While Bytes(baseaddr) <> &H80
                    baseaddr = baseaddr + MergeToInt(Bytes, baseaddr + &H4, baseaddr + &H7) 'Add the length of the attribute to the base address to find the next attribute
                End While
                Dim Length As ULong = 0
                Dim LenLen As Byte = 0
                Dim Offset As ULong = 0
                Dim OffLen As Byte = 0
                Dim ReadSize As ULong = 0
                AddOn = ""
                AddOnNum = 0
ReCheck:
                If My.Computer.FileSystem.FileExists(Dir & "\" & Item.Text & AddOn) Then
                    AddOnNum = AddOnNum + 1
                    AddOn = "(" & AddOnNum.ToString & ")"
                    GoTo ReCheck
                End If
                Dim TempFile As New System.IO.FileStream(Dir & "\" & System.IO.Path.GetFileNameWithoutExtension(Item.Text) & AddOn & System.IO.Path.GetExtension(Item.Text), IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
                If MergeToInt(Bytes, baseaddr + &HE, baseaddr + &HF) = 1 And (buffer.BytesPerFileRecordSegment - (baseaddr + &H18 + FileLength)) > 0 Then
                    Try
                        TempFile.Write(ByteArrayPart(Bytes, baseaddr + &H18, baseaddr + &H18 + FileLength), 0, FileLength)
                    Catch
                        Errors = True
                    End Try
                    GoTo CleanUp
                End If
                baseaddr = baseaddr + &H40
                While Bytes(baseaddr) > 0
                    LenLen = Bytes(baseaddr) And &HF
                    OffLen = (Bytes(baseaddr) And &HF0) / &H10
                    Length = MergeToInt(Bytes, baseaddr + 1, baseaddr + LenLen)
                    Offset = Offset + MergeToInt(Bytes, baseaddr + 1 + LenLen, baseaddr + LenLen + OffLen)
                    If Length <= 1024 Then
                        TempFile.Write(RBM.ReadSectors(Offset * (buffer.BytesPerCluster / buffer.BytesPerSector), Length * (buffer.BytesPerCluster / buffer.BytesPerSector)), 0, Length * buffer.BytesPerCluster)
                    Else
                        For Section = 0 To Length \ 1024
                            If Section = Length \ 1024 Then
                                TempFile.Write(RBM.ReadSectors((Offset + (Section * 1024)) * (buffer.BytesPerCluster / buffer.BytesPerSector), (Length Mod 1024) * (buffer.BytesPerCluster / buffer.BytesPerSector)), 0, (Length Mod 1024) * buffer.BytesPerCluster)
                            Else
                                TempFile.Write(RBM.ReadSectors((Offset + (Section * 1024)) * (buffer.BytesPerCluster / buffer.BytesPerSector), 1024 * (buffer.BytesPerCluster / buffer.BytesPerSector)), 0, 1024 * buffer.BytesPerCluster)
                            End If
                            ToolStripStatusLabel1.Text = "Recovering file " & Item.Text & " " & round(((ReadSize + (Section * 1024)) * buffer.BytesPerCluster * 100) / FileLength, 1) & "%..."
                            If ((ReadSize + (Section * 1024)) * buffer.BytesPerCluster) > FileLength Then Exit While
                            Application.DoEvents()
                        Next
                    End If
                    ReadSize = ReadSize + Length
                    ToolStripStatusLabel1.Text = "Recovering file " & Item.Text & " " & round((ReadSize * buffer.BytesPerCluster * 100) / FileLength, 1) & "%..."
                    If (ReadSize * buffer.BytesPerCluster) > FileLength Then Exit While
                    'Try
                    'ProgressBar1.Value = CInt((ReadSize * buffer.BytesPerCluster * 1000) / FileLength)
                    'Catch
                    'ProgressBar1.Value = 1000
                    'End Try
                    Application.DoEvents()
                    baseaddr = baseaddr + (1 + LenLen + OffLen)
                End While
CleanUp:
        TempFile.SetLength(FileLength)
        TempFile.Close()
        TempFile.Dispose()
        'MsgBox("File recovered successfuly.", MsgBoxStyle.Information, "")
            Catch
            Errors = True

            'MsgBox("File not recovered.", MsgBoxStyle.Critical, "ERROR")
        End Try
DoNext:
        Item.Checked = False
        Next
        ToolStripStatusLabel1.Text = ""
        ProgressBar1.Value = 0
        If Not Errors Then
            MsgBox("Files recovered successfuly.", MsgBoxStyle.Information, "")
        Else
            MsgBox("File recovered with errors.", MsgBoxStyle.Exclamation, "")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListView1.Items.Clear()
        Dim ItemOn As ULong = 0
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = ListView2.Items.Count
        For Each Item As ListViewItem In ListView2.Items
            ItemOn = ItemOn + 1
            ProgressBar1.Value = ItemOn
            If Item.Text.ToUpper.Contains(TextBox2.Text.ToUpper) Then ListView1.Items.Add(Item.Clone)
        Next
        ProgressBar1.Value = 0
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            If Button3.Enabled Then Button3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        Try
            Form2.Show(Me)
        Catch
            Form2.Activate()
        End Try
        Form2.BackgroundImage = PictureBox1.Image
    End Sub

End Class


#Region "DIRECT DISK IO API"
Public Class DirectDriveIO
    Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer
    Private Declare Function ReadFile Lib "kernel32" (ByVal hFile As Integer, ByRef lpBuffer As Object, ByVal nNumberOfBytesToRead As Integer, ByRef lpNumberOfBytesRead As Integer, ByVal lpOverlapped As Integer) As Boolean
    Private Declare Function SetFilePointer Lib "kernel32" (ByVal hFile As Integer, ByVal lDistanceToMove As Integer, ByVal lpDistanceToMoveHigh As Integer, ByVal dwMoveMethod As Integer) As Integer
    Private Declare Function SetFilePointerEx Lib "kernel32" (ByVal hFile As Integer, ByVal liDistanceToMove As Int64, ByRef lpNewFilePointer As Int64, ByVal dwMoveMethod As Integer) As Boolean
    Private Declare Function DeviceIoControlNTFS Lib "kernel32" Alias "DeviceIoControl" (ByVal hDevice As Int32, ByVal dwIoControlCode As Int32, ByRef lpInBuffer As Object, ByVal nInBufferSize As Int32, ByRef lpOutBuffer As NTFS_VOLUME_DATA_BUFFER, ByVal nOutBufferSize As Int32, ByRef lpBytesReturned As Int32, ByVal lpOverlapped As Int32) As Int32
    Private Declare Function DeviceIoControlPropertyAccessAlignment Lib "kernel32" Alias "DeviceIoControl" (ByVal hDevice As Int32, ByVal dwIoControlCode As Int32, ByRef lpInBuffer As STORAGE_PROPERTY_QUERY, ByVal nInBufferSize As Int32, ByRef lpOutBuffer As STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR, ByVal nOutBufferSize As Int32, ByRef lpBytesReturned As Int32, ByVal lpOverlapped As Int32) As Int32
    Private Declare Function DeviceIoControlNumber Lib "kernel32" Alias "DeviceIoControl" (ByVal hDevice As Int32, ByVal dwIoControlCode As Int32, ByRef lpInBuffer As Object, ByVal nInBufferSize As Int32, ByRef lpOutBuffer As _STORAGE_DEVICE_NUMBER, ByVal nOutBufferSize As Int32, ByRef lpBytesReturned As Int32, ByVal lpOverlapped As Int32) As Int32
    Private Structure _STORAGE_DEVICE_NUMBER
        Dim DeviceType As Int32
        Dim DeviceNumber As ULong
        Dim PartitionNumber As ULong
    End Structure
    Private Structure STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR
        Dim Version As Integer
        Dim Size As Integer
        Dim BytesPerCacheLine As Integer
        Dim BytesOffsetForCacheAllignment As Integer
        Dim BytesPerLogicalSector As Integer
        Dim BytesPerPhysicalSector As Integer
        Dim BytesOffsetForSectorAllignment As Integer
    End Structure
    Private Structure STORAGE_PROPERTY_QUERY
        Dim PropertyId As STORAGE_PROPERTY_ID
        Dim QueryType As STORAGE_QUERY_TYPE
        Dim AdditionalParameters As Byte
    End Structure
    Private Structure NTFS_VOLUME_DATA_BUFFER
        Dim VolumeSerialNumber As Int64
        Dim NumberSectors As Int64
        Dim TotalClusters As Int64
        Dim FreeClusters As Int64
        Dim TotalReserved As Int64
        Dim BytesPerSector As Int32 'UInt32
        Dim BytesPerCluster As Int32 'UInt32
        Dim BytesPerFileRecordSegment As Int32 'UInt32
        Dim ClustersPerFileRecordSegment As Int32 'UInt32
        Dim MftValidDataLength As Int64
        Dim MftStartLcn As Int64
        Dim Mft2StartLcn As Int64
        Dim MftZoneStart As Int64
        Dim MftZoneEnd As Int64
    End Structure
    Private Enum STORAGE_PROPERTY_ID
        StorageDeviceProperty = 0
        StorageAdapterProperty
        StorageDeviceIdProperty
        StorageDeviceUniqueIdProperty
        StorageDeviceWriteCacheProperty
        StorageMiniportProperty
        StorageAccessAlignmentProperty
        StorageDeviceSeekPenaltyProperty
        StorageDeviceTrimProperty
    End Enum
    Private Enum STORAGE_QUERY_TYPE
        PropertyStandardQuery = 0
        PropertyExistsQuery
    End Enum
    Private Enum EFileAccess As System.Int32
        DELETE = &H10000
        READ_CONTROL = &H20000
        WRITE_DAC = &H40000
        WRITE_OWNER = &H80000
        SYNCHRONIZE = &H100000
        STANDARD_RIGHTS_REQUIRED = &HF0000
        STANDARD_RIGHTS_READ = READ_CONTROL
        STANDARD_RIGHTS_WRITE = READ_CONTROL
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL
        STANDARD_RIGHTS_ALL = &H1F0000
        SPECIFIC_RIGHTS_ALL = &HFFFF
        ACCESS_SYSTEM_SECURITY = &H1000000
        MAXIMUM_ALLOWED = &H2000000
        GENERIC_READ = &H80000000
        GENERIC_WRITE = &H40000000
        GENERIC_EXECUTE = &H20000000
        GENERIC_ALL = &H10000000
    End Enum
    Private Enum EFileShare
        FILE_SHARE_NONE = &H0
        FILE_SHARE_READ = &H1
        FILE_SHARE_WRITE = &H2
        FILE_SHARE_DELETE = &H4
    End Enum
    Private Enum ECreationDisposition
        CREATE_NEW = 1
        CREATE_ALWAYS = 2
        OPEN_EXISTING = 3
        OPEN_ALWAYS = 4
        TRUNCATE_EXISTING = 5
    End Enum
    Private Enum EFileAttributes
        FILE_ATTRIBUTE_READONLY = &H1
        FILE_ATTRIBUTE_HIDDEN = &H2
        FILE_ATTRIBUTE_SYSTEM = &H4
        FILE_ATTRIBUTE_DIRECTORY = &H10
        FILE_ATTRIBUTE_ARCHIVE = &H20
        FILE_ATTRIBUTE_DEVICE = &H40
        FILE_ATTRIBUTE_NORMAL = &H80
        FILE_ATTRIBUTE_TEMPORARY = &H100
        FILE_ATTRIBUTE_SPARSE_FILE = &H200
        FILE_ATTRIBUTE_REPARSE_POINT = &H400
        FILE_ATTRIBUTE_COMPRESSED = &H800
        FILE_ATTRIBUTE_OFFLINE = &H1000
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
        FILE_ATTRIBUTE_ENCRYPTED = &H4000
        FILE_ATTRIBUTE_VIRTUAL = &H10000
        FILE_FLAG_BACKUP_SEMANTICS = &H2000000
        FILE_FLAG_DELETE_ON_CLOSE = &H4000000
        FILE_FLAG_NO_BUFFERING = &H2000000
        FILE_FLAG_OPEN_NO_RECALL = &H100000
        FILE_FLAG_OPEN_REPARSE_POINT = &H200000
        FILE_FLAG_OVERLAPPED = &H40000000
        FILE_FLAG_POSIX_SEMANTICS = &H100000
        FILE_FLAG_RANDOM_ACCESS = &H10000000
        FILE_FLAG_SEQUENTIAL_SCAN = &H8000000
        FILE_FLAG_WRITE_THROUGH = &H80000000
    End Enum
    Private Enum FILE_DEVICE
        FILE_DEVICE_BEEP = 1
        FILE_DEVICE_CD_ROM
        FILE_DEVICE_CD_ROM_FILE_SYSTEM
        FILE_DEVICE_CONTROLLER
        FILE_DEVICE_DATALINK
        FILE_DEVICE_DFS
        FILE_DEVICE_DISK
        FILE_DEVICE_DISK_FILE_SYSTEM
        FILE_DEVICE_FILE_SYSTEM
        FILE_DEVICE_INPORT_PORT
        FILE_DEVICE_KEYBOARD
        FILE_DEVICE_MAILSLOT
        FILE_DEVICE_MIDI_IN
        FILE_DEVICE_MIDI_OUT
        FILE_DEVICE_MOUSE
        FILE_DEVICE_MULTI_UNC_PROVIDER
        FILE_DEVICE_NAMED_PIPE
        FILE_DEVICE_NETWORK
        FILE_DEVICE_NETWORK_BROWSER
        FILE_DEVICE_NETWORK_FILE_SYSTEM
        FILE_DEVICE_NULL
        FILE_DEVICE_PARALLEL_PORT
        FILE_DEVICE_PHYSICAL_NETCARD
        FILE_DEVICE_PRINTER
        FILE_DEVICE_SCANNER
        FILE_DEVICE_SERIAL_MOUSE_PORT
        FILE_DEVICE_SERIAL_PORT
        FILE_DEVICE_SCREEN
        FILE_DEVICE_SOUND
        FILE_DEVICE_DEVICE_STREAMS
        FILE_DEVICE_TAPE
        FILE_DEVICE_TAPE_FILE_SYSTEM
        FILE_DEVICE_TRANSPORT
        FILE_DEVICE_UNKNOWN
        FILE_DEVICE_VIDEO
        FILE_DEVICE_VIRTUAL_DISK
        FILE_DEVICE_WAVE_IN
        FILE_DEVICE_WAVE_OUT
        FILE_DEVICE_8042_PORT
        FILE_DEVICE_NETWORK_REDIRECTOR
        FILE_DEVICE_BATTERY
        FILE_DEVICE_BUS_EXTENDER
        FILE_DEVICE_MODEM
        FILE_DEVICE_VDM
        FILE_DEVICE_MASS_STORAGE
        FILE_DEVICE_SMB
        FILE_DEVICE_KS
        FILE_DEVICE_CHANGER
        FILE_DEVICE_SMARTCARD
        FILE_DEVICE_ACPI
        FILE_DEVICE_DVD
        FILE_DEVICE_FULLSCREEN_VIDEO
        FILE_DEVICE_DFS_FILE_SYSTEM
        FILE_DEVICE_DFS_VOLUME
    End Enum
    Private Const FILE_ANY_ACCESS = &H0
    Private Const FILE_READ_ACCESS = &H1
    Private Const FILE_WRITE_ACCESS = &H2
    Private Const METHOD_BUFFERED = &H0
    Private Const METHOD_IN_DIRECT = &H1
    Private Const METHOD_OUT_DIRECT = &H2
    Private Const METHOD_NEITHER = &H3
    Private DriveHandle As IntPtr
    Private DiskName As String
    Private SectorSize As Integer
    Private MaxSector As Long
    Private DirectDeviceAccess As Boolean = False
    Private Const FILE_BEGIN = 0
    Private fs As System.IO.FileStream
    Sub New(ByVal Drive As String, Optional ByVal DirectAccess As Boolean = False)
        DirectDeviceAccess = DirectAccess
        Disk = Drive
    End Sub
    Public Function ReadSectors(ByVal StartingLogicalSector As Long, ByVal NumberOfSectors As Integer) As Byte()
        'SetFilePointer(DriveHandle, StartingLogicalSector * SectorSize, 0, FILE_BEGIN)
        fs.Seek(StartingLogicalSector * CLng(SectorSize), IO.SeekOrigin.Begin)
        'SetFilePointerEx(DriveHandle, StartingLogicalSector * CLng(SectorSize), 0, FILE_BEGIN)
        'Dim Buffer() As Byte
        Dim Buffer((NumberOfSectors * SectorSize) - 1) As Byte
        'If Not ReadFile(DriveHandle, Buffer(0), NumberOfSectors * SectorSize, 0, 0) Then Return Nothing
        fs.Read(Buffer, 0, NumberOfSectors * SectorSize)
        'ReadFile(DriveHandle, Buffer(0), NumberOfSectors * SectorSize, 0, 0)
        'MsgBox(Err.LastDllError)
        Return Buffer
    End Function
    Public Function WriteSectors(ByVal StartingLogicalSector As Long, ByVal WriteBytes() As Byte) As Boolean
        'SetFilePointer(DriveHandle, StartingLogicalSector * SectorSize, 0, FILE_BEGIN)
        fs.Seek(StartingLogicalSector * CLng(SectorSize), IO.SeekOrigin.Begin)
        'SetFilePointerEx(DriveHandle, StartingLogicalSector * CLng(SectorSize), 0, FILE_BEGIN)
        'Dim fs As New System.IO.FileStream(DriveHandle, IO.FileAccess.ReadWrite)
        Try
            fs.Write(WriteBytes, 0, WriteBytes.Count)
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Function ReadAddress(ByVal StartAddress As Long, ByVal NumberOfBytes As Long) As Byte()
        fs.Seek(StartAddress, IO.SeekOrigin.Begin)
        Dim Buffer(NumberOfBytes - 1) As Byte
        fs.Read(Buffer, 0, NumberOfBytes)
        Return Buffer
    End Function
    Public Function WriteAddress(ByVal StartAddress As Long, ByVal WriteBytes() As Byte) As Boolean
        fs.Seek(StartAddress, IO.SeekOrigin.Begin)
        Try
            fs.Write(WriteBytes, 0, WriteBytes.Count)
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Property Disk() As String
        Get
            Return DiskName
        End Get
        Set(ByVal value As String)
            DiskName = value
            Dim drive = DiskName
            drive = drive.TrimEnd("\")
            'Dim diskhandle = CreateFile(devicepathname(drive & "\").TrimEnd("\"), EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            Dim diskhandle As Integer
            If DirectDeviceAccess Then
                diskhandle = CreateFile("\\?\" & PhysicalDrive(drive), EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            Else
                diskhandle = CreateFile("\\?\" & drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            End If
            If diskhandle = 0 Then
                diskhandle = CreateFile("\\.\" & drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
                If diskhandle = 0 Then
                    Throw New Exception("Could not access disk.")
                    Exit Property
                End If
            End If
            DriveHandle = diskhandle
            fs = New System.IO.FileStream(DriveHandle, IO.FileAccess.ReadWrite)
            Dim FSCTL_GET_NFTS_VOLUME_DATA = CTL_CODE(FILE_DEVICE.FILE_DEVICE_FILE_SYSTEM, 25, METHOD_BUFFERED, FILE_ANY_ACCESS)
            Dim IOCTL_STORAGE_QUERY_PROPERTY = CTL_CODE(FILE_DEVICE.FILE_DEVICE_MASS_STORAGE, &H500, METHOD_BUFFERED, FILE_ANY_ACCESS)
            Dim buffer As NTFS_VOLUME_DATA_BUFFER
            Dim propaabuffer As STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR
            DeviceIoControlNTFS(diskhandle, FSCTL_GET_NFTS_VOLUME_DATA, 0, 0, buffer, SizeOf(buffer), 0, 0)
            Dim query As New STORAGE_PROPERTY_QUERY
            query.QueryType = STORAGE_QUERY_TYPE.PropertyStandardQuery
            query.PropertyId = STORAGE_PROPERTY_ID.StorageAccessAlignmentProperty
            DeviceIoControlPropertyAccessAlignment(diskhandle, IOCTL_STORAGE_QUERY_PROPERTY, query, SizeOf(query), propaabuffer, SizeOf(propaabuffer), 0, 0)
            Dim BytesPerSector = buffer.BytesPerSector
            If BytesPerSector = 0 Then
                BytesPerSector = propaabuffer.BytesPerPhysicalSector
                If BytesPerSector = 0 Then BytesPerSector = 512
            End If
            SectorSize = BytesPerSector
            MaxSector = buffer.NumberSectors - 1
            If MaxSector = 0 Or MaxSector = -1 Then
                Try
                    MaxSector = CLng(My.Computer.FileSystem.GetDriveInfo(DiskName).TotalSize / CLng(SectorSize))
                Catch
                    Throw New Exception("Could not access disk.")
                    Exit Property
                End Try
                If MaxSector = 0 Then
                    Throw New Exception("Could not access disk.")
                    Exit Property
                End If
            End If
        End Set
    End Property
    Public ReadOnly Property LastSector() As Long
        Get
            Return MaxSector
        End Get
    End Property
    Public Property DirectAccess() As Boolean
        Get
            Return DirectDeviceAccess
        End Get
        Set(ByVal value As Boolean)
            DirectDeviceAccess = value
            Try
                Disk = Disk
            Catch
            End Try
        End Set
    End Property
    Public ReadOnly Property BytesPerSector() As Integer
        Get
            Return SectorSize
        End Get
    End Property
    Private Function CTL_CODE(ByVal DeviceType As Int32, ByVal FunctionNumber As Int32, ByVal Method As Int32, ByVal Access As Int32) As Int32
        Return (DeviceType << 16) Or (Access << 14) Or (FunctionNumber << 2) Or Method
    End Function
    Private Function PhysicalDrive(ByVal Drive As String) As String
        Dim devn As Integer = -1
        For Each Driver As System.IO.DriveInfo In My.Computer.FileSystem.Drives
            If Driver.DriveType = IO.DriveType.Fixed Or Driver.DriveType = IO.DriveType.Removable Then devn = devn + 1
            If Driver.Name.TrimEnd("\") = UCase(Drive.TrimEnd("\")) Then Return "PhysicalDrive" & devn.ToString
        Next
        Dim diskhandle = CreateFile("\\?\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
        If diskhandle = 0 Then
            diskhandle = CreateFile("\\.\" & Drive, EFileAccess.GENERIC_READ + EFileAccess.GENERIC_WRITE, EFileShare.FILE_SHARE_READ + EFileShare.FILE_SHARE_WRITE, Nothing, ECreationDisposition.OPEN_EXISTING, 0, Nothing)
            If diskhandle = 0 Then
                Throw New Exception("Could not access disk.")
                Exit Function
            End If
        End If
        Dim IOCTL_STORAGE_GET_DEVICE_NUMBER = CTL_CODE(FILE_DEVICE.FILE_DEVICE_MASS_STORAGE, &H420, METHOD_BUFFERED, FILE_ANY_ACCESS)
        Dim dnbuffer As _STORAGE_DEVICE_NUMBER
        DeviceIoControlNumber(diskhandle, IOCTL_STORAGE_GET_DEVICE_NUMBER, 0, 0, dnbuffer, SizeOf(dnbuffer), 0, 0)
        dnbuffer.DeviceNumber = 0
        Return "PhysicalDrive" & dnbuffer.DeviceNumber.ToString
    End Function
End Class
#End Region
