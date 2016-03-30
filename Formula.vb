'   2016    3   27 (Easter)
'   Author: Abdiel Reginald, 17a7ff2b6731@gmail.com
'   This file is the formulas for PhyCal
'   PhyCal is the project for Physic Project in JCTIC (2015-2016)
'   Build:  16H12A
'   Initial Build: 16A02A
'   Build Code Algorithm:   [Year (2 dights)][Type*(1 character)][Week Number (2 dights)][No.of build of that week]
'   Year : 2015:  15,   2016:   16 ,etc
'   Type:
'           A   =   Alpha       ,   B   =   Beta    ,   C   =   Public Beta / Pre-Final ,   D   =   Public Release (Final)  ,   H   =   RollBack Alpha (For next release of PhyCal 2016C2)
'   No.of Build of that week : 1st release = A, 2nd Release =B (eg 16A07D = The fourth alpha release of 7th week of year 2016)
'   ####### Sorry for bad code  #########

'Section:
'   1   Heat Capacity
'   2   Thermal Conductivity
'   3   Thermal Expansion
Imports PhyCal.AdditionalLogger
Module Formula
    '================================   Section 1 (Heat Capacity)   ================================='
    'A simple Visual Basic Library for calculating Heat Capacity'
    'Creating Date: 3/2/2016
    'Written By ICM.
    'Build : 16H12A
    'Initial build : 16A04
    'Function:
    'Heat_Capacity()  -> Get Heat Capacity
    'Energy() -> Get Energy Released
    'TempChange() -> Get Temperature Difference
    'weight() -> Get the mass of object with E=mc(T-T')
    'Just Equations =w='
    'Use Specific Tag to make it specific or general.
    Public Function Heat_Capacity(ByVal deltaT As Double, ByVal Energy As Double, ByVal mass As Double, ByVal Specific As Int16) As String
        If Specific = 1 Then
            Return Energy / (deltaT * mass)
            Exit Function
        ElseIf Specific = 0 Then
            Return Energy / deltaT
            Exit Function
        End If
        Return 127
    End Function
    Public Function Energy(ByVal deltaT As Double, ByVal hcapacity As Double, ByVal scapacity As Double, ByVal mass As Double, ByVal Specific As Int16) As String
        If Specific = 0 Then
            Return hcapacity * deltaT
        ElseIf Specific = 1 Then
            Return scapacity * deltaT * mass
            Exit Function
        End If
        Return 127
        Exit Function
    End Function
    Public Function TempChange(ByVal Engr As Double, ByVal hcapacity As Double, ByVal scapacity As Double, ByVal mass As Double, ByVal Specific As Int16)
        If Specific = 0 Then
            Return Engr / hcapacity
        ElseIf Specific = 1 Then
            Return Engr / (scapacity * mass)
        End If
        Return 127
    End Function
    Public Function weight(ByVal Engr As Double, ByVal scapacity As Double, ByVal deltaT As Double)
        Return Engr / scapacity / deltaT
        Exit Function
    End Function
    '================================   Section 2 (Thermal Conductivity)   ===============================
    'Initial Build : 16H12A
    'Build : 16H12A
    'Written by Abdiel Reginald <17a7ff2b6731@gmail.com>
    'k = Q / A * ∆T
    'k Is thermal conductivity in W/m K,
    'Q Is amount of heat transfer through the material in J/S Or W,
    'A Is the area of the body in m^2,
    'ΔT Is difference in temperature in K.
    'Conductivity(): Return the Heat Conductivity
    'Heat(): Return the Heat Transferred
    'Bodyarea(): Return the area of body
    'DiffTemp(): Return the Temperature Change
    Public Function Conductivity(ByVal heat As Double, ByVal area As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Conductivity > Calculating the Temperature Difference, applying formula k = Q / (A * ∆T)")
        AdditionalLogger.Log(" Thermal Conductivity > k = " & heat & " / ( " & area & " * " & tempchange & " )")
        AdditionalLogger.Log(" Thermal Conductivity > k = " & heat / (area * tempchange))
        Return heat / (area * tempchange)
        Exit Function
    End Function
    Public Function Heat(ByVal conductivity As Double, ByVal area As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Conductivity > Calculating the Temperature Difference, applying formula Q = k * A * ∆T")
        AdditionalLogger.Log(" Thermal Conductivity > Q = " & conductivity & " * " & area & " * " & tempchange)
        AdditionalLogger.Log(" Thermal Conductivity > Q = " & conductivity * area * tempchange)
        Return conductivity * area * tempchange
        Exit Function
    End Function
    Public Function Bodyarea(ByVal heat As Double, ByVal conductivity As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Conductivity > Calculating the Temperature Difference, applying formula A = Q / (k * ∆T)")
        AdditionalLogger.Log(" Thermal Conductivity > A = " & heat & " / ( " & conductivity & " * " & tempchange & " )")
        AdditionalLogger.Log(" Thermal Conductivity > A = " & heat / (conductivity * tempchange))
        Return heat / (conductivity * tempchange)
        Exit Function
    End Function
    Public Function DiffTemp(ByVal heat As Double, ByVal conductivity As Double, ByVal area As Double)
        AdditionalLogger.Log(" Thermal Conductivity > Calculating the Temperature Difference, applying formula ∆T = Q / (k * A)")
        AdditionalLogger.Log(" Thermal Conductivity > ∆T = " & heat & " / ( " & conductivity & " * " & area & " )")
        AdditionalLogger.Log(" Thermal Conductivity > ∆T = " & heat / (conductivity * area))
        Return heat / (conductivity * area)
        Exit Function
    End Function
    '===========================    Section 3 (Thermal Expansion)   ============================'
    '   Initial Build : 16H12A
    '   Build : 16H12A
    '   Written by Abdiel Reginald <17a7ff2b6731@gmail.com>
    '   ΔL / L0= αL ΔT
    '   L0 is original length,
    '   L Is the expanded length,
    '   αL Is length expansion coefficient,
    '   ΔT Is temperature difference,
    '   ΔL Is change in length.
    'Function :
    'Changedata() : For the change of the size
    'Originaldata() : For the original size
    'Coefficient() : For the expanding coefficient
    'TempDiff() : For the temperature change
    Public Function Changedata(ByVal original As Double, ByVal coefficient As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Expansion > Calculating the Change of Size, applying formula ∆L = αL * ∆T *　Ｌo")
        AdditionalLogger.Log(" Thermal Expansion > ∆L = " & coefficient & " * " & tempchange & " * " & original)
        AdditionalLogger.Log(" Thermal Expansion > ∆L = " & coefficient * tempchange * original)
        Return coefficient * tempchange * original
    End Function
    Public Function Originaldata(ByVal datachange As Double, ByVal coefficient As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Expansion > Calculating the Original Size, applying formula Lo = ∆L / (αL * ∆T)")
        AdditionalLogger.Log(" Thermal Expansion > Lo = " & datachange & " / ( " & coefficient & " * " & tempchange & " )")
        AdditionalLogger.Log(" Thermal Expansion > Lo = " & datachange / (coefficient * tempchange))
        Return datachange / (coefficient * tempchange)
    End Function
    Public Function Coefficient(ByVal original As Double, ByVal datachange As Double, ByVal tempchange As Double)
        AdditionalLogger.Log(" Thermal Expansion > Calculating the Expansion coefficient, applying formula αL = ∆L / (∆T * Lo)")
        AdditionalLogger.Log(" Thermal Expansion > αL = " & datachange & " / ( " & original & " * " & tempchange & " )")
        AdditionalLogger.Log(" Thermal Expansion > αL = " & datachange / (original * tempchange))
        Return datachange / (tempchange * original)
    End Function
    Public Function TempDiff(ByVal original As Double, ByVal datachange As Double, ByVal coefficient As Double)
        AdditionalLogger.Log(" Thermal Expansion > Calculating the Temperature Difference, applying formula αL = ∆L / (∆T * Lo)")
        AdditionalLogger.Log(" Thermal Expansion > ∆T = " & datachange & " / ( " & original & " * " & coefficient & " )")
        AdditionalLogger.Log(" Thermal Expansion > ∆T = " & datachange / (original * coefficient))
        Return datachange / (coefficient * original)
    End Function
End Module
