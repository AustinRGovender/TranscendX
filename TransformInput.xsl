<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/Parent'>
    <Root>
      <FName>
        <xsl:value-of select='FirstName'/>
      </FName>
      <MName>
        <xsl:element name='MiddleName'/>
      </MName>
      <LName>
        <xsl:value-of select='LastName'/>
      </LName>
      <EmailAddress>
        <xsl:value-of select='EmailId'/>
      </EmailAddress>
      <CellNumber>
        <xsl:value-of select='Mobile'/>
      </CellNumber>
      <PhysicalAddress>
        <xsl:value-of select='Address'/>
      </PhysicalAddress>
      <CarBrand>
        <xsl:value-of select='Car'/>
      </CarBrand>
      
    </Root>
  </xsl:template>
</xsl:stylesheet>