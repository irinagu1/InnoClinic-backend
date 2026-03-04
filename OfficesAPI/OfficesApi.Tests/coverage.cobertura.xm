<?xml version="1.0" encoding="utf-8"?>
<coverage line-rate="0.056100000000000004" branch-rate="0.0416" version="1.9" timestamp="1772618769" lines-covered="10" lines-valid="178" branches-covered="1" branches-valid="24">
  <sources>
    <source>/home/iryna/IrynaDocs/Files/InnoClinic/Backend/OfficesAPI/</source>
  </sources>
  <packages>
    <package name="OfficesApi.Domain" line-rate="0" branch-rate="1" complexity="7">
      <classes>
        <class name="OfficesApi.Domain.Office" filename="OfficesApi.Domain/Office.cs" line-rate="0" branch-rate="1" complexity="7">
          <methods>
            <method name="get_Id" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_City" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_Street" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_HouseNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="8" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_OfficeNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="9" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_RegistryPhoneNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="10" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_IsActive" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="11" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="5" hits="0" branch="False" />
            <line number="6" hits="0" branch="False" />
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="10" hits="0" branch="False" />
            <line number="11" hits="0" branch="False" />
          </lines>
        </class>
      </classes>
    </package>
    <package name="OfficesApi.Shared" line-rate="1" branch-rate="1" complexity="1">
      <classes>
        <class name="OfficesApi.Shared.NotFoundException" filename="OfficesApi.Shared/Exceptions/NotFoundException.cs" line-rate="1" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(System.String,System.String)" line-rate="1" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="1" branch="False" />
                <line number="7" hits="1" branch="False" />
                <line number="8" hits="1" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="6" hits="1" branch="False" />
            <line number="7" hits="1" branch="False" />
            <line number="8" hits="1" branch="False" />
          </lines>
        </class>
      </classes>
    </package>
    <package name="OfficesApi.Application" line-rate="0.0416" branch-rate="0.0416" complexity="63">
      <classes>
        <class name="HelperService/&lt;CheckIfOfficeExistByIdAsync&gt;d__0" filename="OfficesApi.Application/Offices/SharedBehaviour/HelperService.cs" line-rate="0" branch-rate="0" complexity="2">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="0" complexity="2">
              <lines>
                <line number="8" hits="0" branch="False" />
                <line number="9" hits="0" branch="False" />
                <line number="11" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="157" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="12" hits="0" branch="False" />
                <line number="14" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="11" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="157" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="12" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.MappingProfile" filename="OfficesApi.Application/MappingProfile.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="10" hits="0" branch="False" />
                <line number="11" hits="0" branch="False" />
                <line number="12" hits="0" branch="False" />
                <line number="13" hits="0" branch="False" />
                <line number="14" hits="0" branch="False" />
                <line number="15" hits="0" branch="False" />
                <line number="16" hits="0" branch="False" />
                <line number="17" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="10" hits="0" branch="False" />
            <line number="11" hits="0" branch="False" />
            <line number="12" hits="0" branch="False" />
            <line number="13" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
            <line number="15" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="17" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.PartiallyUpdate.PartiallyUpdateOfficeCommand" filename="OfficesApi.Application/Offices/PartiallyUpdate/PartiallyUpdateOfficeCommand.cs" line-rate="0" branch-rate="1" complexity="2">
          <methods>
            <method name="get_id" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
              </lines>
            </method>
            <method name=".ctor" signature="(System.String,System.Collections.Generic.Dictionary`2&lt;System.String,System.Object&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="6" hits="0" branch="False" />
            <line number="5" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.PartiallyUpdate.PartiallyUpdateOfficeCommandHandler" filename="OfficesApi.Application/Offices/PartiallyUpdate/PartiallyUpdateOfficeCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(IHelperService,OfficesApi.Application.Abstractions.Data.IOfficeRepository,Microsoft.Extensions.Logging.ILogger`1&lt;OfficesApi.Application.Offices.PartiallyUpdate.PartiallyUpdateOfficeCommandHandler&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
                <line number="8" hits="0" branch="False" />
                <line number="9" hits="0" branch="False" />
                <line number="10" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="10" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.PartiallyUpdate.PartiallyUpdateOfficeCommandHandler/&lt;Handle&gt;d__4" filename="OfficesApi.Application/Offices/PartiallyUpdate/PartiallyUpdateOfficeCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="15" hits="0" branch="False" />
                <line number="16" hits="0" branch="False" />
                <line number="17" hits="0" branch="False" />
                <line number="18" hits="0" branch="False" />
                <line number="19" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="15" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="17" hits="0" branch="False" />
            <line number="18" hits="0" branch="False" />
            <line number="19" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.PartiallyUpdate.PartiallyUpdateOfficeCommandValidator" filename="OfficesApi.Application/Offices/PartiallyUpdate/PartiallyUpdateOfficeCommandValidator.cs" line-rate="0" branch-rate="0" complexity="14">
          <methods>
            <method name="GetAcceptableKeyNames" signature="()" line-rate="0" branch-rate="0" complexity="6">
              <lines>
                <line number="48" hits="0" branch="False" />
                <line number="49" hits="0" branch="False" />
                <line number="51" hits="0" branch="False" />
                <line number="53" hits="0" branch="False" />
                <line number="55" hits="0" branch="False" />
                <line number="56" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="71" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="57" hits="0" branch="False" />
                <line number="59" hits="0" branch="False" />
                <line number="60" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="148" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="61" hits="0" branch="False" />
                <line number="62" hits="0" branch="False" />
                <line number="63" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="124" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="64" hits="0" branch="False" />
                <line number="65" hits="0" branch="False" />
                <line number="66" hits="0" branch="False" />
                <line number="67" hits="0" branch="False" />
              </lines>
            </method>
            <method name="&lt;.ctor&gt;b__2_4" signature="(System.Collections.Generic.KeyValuePair`2&lt;System.String,System.Object&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="31" hits="0" branch="False" />
              </lines>
            </method>
            <method name=".ctor" signature="()" line-rate="0" branch-rate="0" complexity="6">
              <lines>
                <line number="16" hits="0" branch="False" />
                <line number="17" hits="0" branch="False" />
                <line number="18" hits="0" branch="False" />
                <line number="20" hits="0" branch="False" />
                <line number="21" hits="0" branch="False" />
                <line number="22" hits="0" branch="False" />
                <line number="24" hits="0" branch="False" />
                <line number="25" hits="0" branch="False" />
                <line number="26" hits="0" branch="False" />
                <line number="28" hits="0" branch="False" />
                <line number="29" hits="0" branch="False" />
                <line number="30" hits="0" branch="False" />
                <line number="32" hits="0" branch="False" />
                <line number="33" hits="0" branch="False" />
                <line number="34" hits="0" branch="False" />
                <line number="35" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="20" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="36" hits="0" branch="False" />
                <line number="37" hits="0" branch="True" condition-coverage="0% (0/4)">
                  <conditions>
                    <condition number="45" type="jump" coverage="0%" />
                    <condition number="74" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="38" hits="0" branch="False" />
                <line number="39" hits="0" branch="False" />
                <line number="40" hits="0" branch="False" />
                <line number="41" hits="0" branch="False" />
                <line number="42" hits="0" branch="False" />
                <line number="43" hits="0" branch="False" />
                <line number="45" hits="0" branch="False" />
              </lines>
            </method>
            <method name=".cctor" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="11" hits="0" branch="False" />
                <line number="12" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="48" hits="0" branch="False" />
            <line number="49" hits="0" branch="False" />
            <line number="51" hits="0" branch="False" />
            <line number="53" hits="0" branch="False" />
            <line number="55" hits="0" branch="False" />
            <line number="56" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="71" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="57" hits="0" branch="False" />
            <line number="59" hits="0" branch="False" />
            <line number="60" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="148" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="61" hits="0" branch="False" />
            <line number="62" hits="0" branch="False" />
            <line number="63" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="124" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="64" hits="0" branch="False" />
            <line number="65" hits="0" branch="False" />
            <line number="66" hits="0" branch="False" />
            <line number="67" hits="0" branch="False" />
            <line number="31" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="17" hits="0" branch="False" />
            <line number="18" hits="0" branch="False" />
            <line number="20" hits="0" branch="False" />
            <line number="21" hits="0" branch="False" />
            <line number="22" hits="0" branch="False" />
            <line number="24" hits="0" branch="False" />
            <line number="25" hits="0" branch="False" />
            <line number="26" hits="0" branch="False" />
            <line number="28" hits="0" branch="False" />
            <line number="29" hits="0" branch="False" />
            <line number="30" hits="0" branch="False" />
            <line number="32" hits="0" branch="False" />
            <line number="33" hits="0" branch="False" />
            <line number="34" hits="0" branch="False" />
            <line number="35" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="20" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="36" hits="0" branch="False" />
            <line number="37" hits="0" branch="True" condition-coverage="0% (0/4)">
              <conditions>
                <condition number="45" type="jump" coverage="0%" />
                <condition number="74" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="38" hits="0" branch="False" />
            <line number="39" hits="0" branch="False" />
            <line number="40" hits="0" branch="False" />
            <line number="41" hits="0" branch="False" />
            <line number="42" hits="0" branch="False" />
            <line number="43" hits="0" branch="False" />
            <line number="45" hits="0" branch="False" />
            <line number="11" hits="0" branch="False" />
            <line number="12" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetById.GetOfficeByIdQuery" filename="OfficesApi.Application/Offices/GetById/GetOfficeByIdQuery.cs" line-rate="1" branch-rate="1" complexity="1">
          <methods>
            <method name="get_id" signature="()" line-rate="1" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="3" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="6" hits="3" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetById.GetOfficeByIdQueryHandler" filename="OfficesApi.Application/Offices/GetById/GetOfficeByIdQueryHandler.cs" line-rate="1" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(OfficesApi.Application.Abstractions.Data.IOfficeRepository,AutoMapper.IMapper)" line-rate="1" branch-rate="1" complexity="1">
              <lines>
                <line number="9" hits="1" branch="False" />
                <line number="10" hits="1" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="9" hits="1" branch="False" />
            <line number="10" hits="1" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetById.GetOfficeByIdQueryHandler/&lt;Handle&gt;d__3" filename="OfficesApi.Application/Offices/GetById/GetOfficeByIdQueryHandler.cs" line-rate="0.5714" branch-rate="0.5" complexity="2">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0.5714" branch-rate="0.5" complexity="2">
              <lines>
                <line number="15" hits="1" branch="False" />
                <line number="16" hits="1" branch="False" />
                <line number="18" hits="1" branch="True" condition-coverage="50% (1/2)">
                  <conditions>
                    <condition number="169" type="jump" coverage="50%" />
                  </conditions>
                </line>
                <line number="19" hits="1" branch="False" />
                <line number="21" hits="0" branch="False" />
                <line number="23" hits="0" branch="False" />
                <line number="24" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="15" hits="1" branch="False" />
            <line number="16" hits="1" branch="False" />
            <line number="18" hits="1" branch="True" condition-coverage="50% (1/2)">
              <conditions>
                <condition number="169" type="jump" coverage="50%" />
              </conditions>
            </line>
            <line number="19" hits="1" branch="False" />
            <line number="21" hits="0" branch="False" />
            <line number="23" hits="0" branch="False" />
            <line number="24" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetAll.GetAllOfficesQuery" filename="OfficesApi.Application/Offices/GetAll/GetAllOfficesQuery.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="5" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetAll.GetAllOfficesQueryHandler" filename="OfficesApi.Application/Offices/GetAll/GetAllOfficesQueryHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(OfficesApi.Application.Abstractions.Data.IOfficeRepository,AutoMapper.IMapper)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="7" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetAll.GetAllOfficesQueryHandler/&lt;Handle&gt;d__3" filename="OfficesApi.Application/Offices/GetAll/GetAllOfficesQueryHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="13" hits="0" branch="False" />
                <line number="14" hits="0" branch="False" />
                <line number="16" hits="0" branch="False" />
                <line number="18" hits="0" branch="False" />
                <line number="19" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="13" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="18" hits="0" branch="False" />
            <line number="19" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.GetAll.OfficeResponse" filename="OfficesApi.Application/Offices/GetAll/OfficeResponse.cs" line-rate="0" branch-rate="1" complexity="9">
          <methods>
            <method name="get_Id" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_City" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_Street" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_HouseNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="8" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_OfficeNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="9" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_RegistryPhoneNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="10" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_Address" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="11" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_IsActive" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="12" hits="0" branch="False" />
              </lines>
            </method>
            <method name=".ctor" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="14" hits="0" branch="False" />
                <line number="15" hits="0" branch="False" />
                <line number="17" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="5" hits="0" branch="False" />
            <line number="6" hits="0" branch="False" />
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="10" hits="0" branch="False" />
            <line number="11" hits="0" branch="False" />
            <line number="12" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
            <line number="15" hits="0" branch="False" />
            <line number="17" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Delete.DeleteOfficeByIdCommand" filename="OfficesApi.Application/Offices/Delete/DeleteOfficeByIdCommand.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="get_id" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="5" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Delete.DeleteOfficeByIdCommandHandler" filename="OfficesApi.Application/Offices/Delete/DeleteOfficeByIdCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(IHelperService,OfficesApi.Application.Abstractions.Data.IOfficeRepository,Microsoft.Extensions.Logging.ILogger`1&lt;OfficesApi.Application.Offices.Delete.DeleteOfficeByIdCommandHandler&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
                <line number="8" hits="0" branch="False" />
                <line number="9" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Delete.DeleteOfficeByIdCommandHandler/&lt;Handle&gt;d__4" filename="OfficesApi.Application/Offices/Delete/DeleteOfficeByIdCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="13" hits="0" branch="False" />
                <line number="14" hits="0" branch="False" />
                <line number="16" hits="0" branch="False" />
                <line number="18" hits="0" branch="False" />
                <line number="19" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="13" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="18" hits="0" branch="False" />
            <line number="19" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Create.CreateOfficeCommand" filename="OfficesApi.Application/Offices/Create/CreateOfficeCommand.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="get_OfficeCreateDto" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="6" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Create.CreateOfficeCommandHandler" filename="OfficesApi.Application/Offices/Create/CreateOfficeCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(OfficesApi.Application.Abstractions.Data.IOfficeRepository,AutoMapper.IMapper,FluentValidation.IValidator`1&lt;OfficesApi.Application.Offices.Create.OfficeCreate&gt;,Microsoft.Extensions.Logging.ILogger`1&lt;OfficesApi.Application.Offices.Create.CreateOfficeCommandHandler&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="11" hits="0" branch="False" />
                <line number="12" hits="0" branch="False" />
                <line number="13" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="11" hits="0" branch="False" />
            <line number="12" hits="0" branch="False" />
            <line number="13" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Create.CreateOfficeCommandHandler/&lt;Handle&gt;d__5" filename="OfficesApi.Application/Offices/Create/CreateOfficeCommandHandler.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="18" hits="0" branch="False" />
                <line number="19" hits="0" branch="False" />
                <line number="21" hits="0" branch="False" />
                <line number="23" hits="0" branch="False" />
                <line number="25" hits="0" branch="False" />
                <line number="27" hits="0" branch="False" />
                <line number="29" hits="0" branch="False" />
                <line number="30" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="18" hits="0" branch="False" />
            <line number="19" hits="0" branch="False" />
            <line number="21" hits="0" branch="False" />
            <line number="23" hits="0" branch="False" />
            <line number="25" hits="0" branch="False" />
            <line number="27" hits="0" branch="False" />
            <line number="29" hits="0" branch="False" />
            <line number="30" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Create.OfficeCreate" filename="OfficesApi.Application/Offices/Create/OfficeCreate.cs" line-rate="0" branch-rate="1" complexity="6">
          <methods>
            <method name="get_City" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="5" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_Street" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_HouseNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="7" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_OfficeNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="8" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_RegistryPhoneNumber" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="9" hits="0" branch="False" />
              </lines>
            </method>
            <method name="get_IsActive" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="10" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="5" hits="0" branch="False" />
            <line number="6" hits="0" branch="False" />
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="10" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Offices.Create.OfficeCreateValidator" filename="OfficesApi.Application/Offices/Create/OfficeCreateValidator.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="()" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="6" hits="0" branch="False" />
                <line number="7" hits="0" branch="False" />
                <line number="8" hits="0" branch="False" />
                <line number="9" hits="0" branch="False" />
                <line number="10" hits="0" branch="False" />
                <line number="11" hits="0" branch="False" />
                <line number="12" hits="0" branch="False" />
                <line number="13" hits="0" branch="False" />
                <line number="15" hits="0" branch="False" />
                <line number="16" hits="0" branch="False" />
                <line number="17" hits="0" branch="False" />
                <line number="18" hits="0" branch="False" />
                <line number="19" hits="0" branch="False" />
                <line number="20" hits="0" branch="False" />
                <line number="22" hits="0" branch="False" />
                <line number="23" hits="0" branch="False" />
                <line number="24" hits="0" branch="False" />
                <line number="26" hits="0" branch="False" />
                <line number="27" hits="0" branch="False" />
                <line number="28" hits="0" branch="False" />
                <line number="30" hits="0" branch="False" />
                <line number="31" hits="0" branch="False" />
                <line number="32" hits="0" branch="False" />
                <line number="33" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="6" hits="0" branch="False" />
            <line number="7" hits="0" branch="False" />
            <line number="8" hits="0" branch="False" />
            <line number="9" hits="0" branch="False" />
            <line number="10" hits="0" branch="False" />
            <line number="11" hits="0" branch="False" />
            <line number="12" hits="0" branch="False" />
            <line number="13" hits="0" branch="False" />
            <line number="15" hits="0" branch="False" />
            <line number="16" hits="0" branch="False" />
            <line number="17" hits="0" branch="False" />
            <line number="18" hits="0" branch="False" />
            <line number="19" hits="0" branch="False" />
            <line number="20" hits="0" branch="False" />
            <line number="22" hits="0" branch="False" />
            <line number="23" hits="0" branch="False" />
            <line number="24" hits="0" branch="False" />
            <line number="26" hits="0" branch="False" />
            <line number="27" hits="0" branch="False" />
            <line number="28" hits="0" branch="False" />
            <line number="30" hits="0" branch="False" />
            <line number="31" hits="0" branch="False" />
            <line number="32" hits="0" branch="False" />
            <line number="33" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Abstractions.Behaviour.ValidationBehavior`2" filename="OfficesApi.Application/Abstractions/Behaviour/ValidationBehaviour.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name=".ctor" signature="(System.Collections.Generic.IEnumerable`1&lt;FluentValidation.IValidator`1&lt;TRequest&gt;&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="12" hits="0" branch="False" />
                <line number="13" hits="0" branch="False" />
                <line number="14" hits="0" branch="False" />
                <line number="15" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="12" hits="0" branch="False" />
            <line number="13" hits="0" branch="False" />
            <line number="14" hits="0" branch="False" />
            <line number="15" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Abstractions.Behaviour.ValidationBehavior`2/&lt;&gt;c" filename="OfficesApi.Application/Abstractions/Behaviour/ValidationBehaviour.cs" line-rate="0" branch-rate="1" complexity="3">
          <methods>
            <method name="&lt;Handle&gt;b__2_0" signature="(FluentValidation.Results.ValidationResult)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="26" hits="0" branch="False" />
              </lines>
            </method>
            <method name="&lt;Handle&gt;b__2_1" signature="(FluentValidation.Results.ValidationResult)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="27" hits="0" branch="False" />
              </lines>
            </method>
            <method name="&lt;Handle&gt;b__2_2" signature="(FluentValidation.Results.ValidationFailure)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="28" hits="0" branch="False" />
                <line number="29" hits="0" branch="False" />
                <line number="30" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="26" hits="0" branch="False" />
            <line number="27" hits="0" branch="False" />
            <line number="28" hits="0" branch="False" />
            <line number="29" hits="0" branch="False" />
            <line number="30" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Abstractions.Behaviour.ValidationBehavior`2/&lt;&gt;c__DisplayClass2_0" filename="OfficesApi.Application/Abstractions/Behaviour/ValidationBehaviour.cs" line-rate="0" branch-rate="1" complexity="1">
          <methods>
            <method name="&lt;Handle&gt;b__3" signature="(FluentValidation.IValidator`1&lt;TRequest&gt;)" line-rate="0" branch-rate="1" complexity="1">
              <lines>
                <line number="23" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="23" hits="0" branch="False" />
          </lines>
        </class>
        <class name="OfficesApi.Application.Abstractions.Behaviour.ValidationBehavior`2/&lt;Handle&gt;d__2" filename="OfficesApi.Application/Abstractions/Behaviour/ValidationBehaviour.cs" line-rate="0" branch-rate="0" complexity="8">
          <methods>
            <method name="MoveNext" signature="()" line-rate="0" branch-rate="0" complexity="8">
              <lines>
                <line number="19" hits="0" branch="False" />
                <line number="20" hits="0" branch="False" />
                <line number="22" hits="0" branch="False" />
                <line number="25" hits="0" branch="True" condition-coverage="0% (0/6)">
                  <conditions>
                    <condition number="227" type="jump" coverage="0%" />
                    <condition number="263" type="jump" coverage="0%" />
                    <condition number="299" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="31" hits="0" branch="False" />
                <line number="33" hits="0" branch="True" condition-coverage="0% (0/2)">
                  <conditions>
                    <condition number="354" type="jump" coverage="0%" />
                  </conditions>
                </line>
                <line number="34" hits="0" branch="False" />
                <line number="35" hits="0" branch="False" />
                <line number="38" hits="0" branch="False" />
                <line number="40" hits="0" branch="False" />
                <line number="41" hits="0" branch="False" />
              </lines>
            </method>
          </methods>
          <lines>
            <line number="19" hits="0" branch="False" />
            <line number="20" hits="0" branch="False" />
            <line number="22" hits="0" branch="False" />
            <line number="25" hits="0" branch="True" condition-coverage="0% (0/6)">
              <conditions>
                <condition number="227" type="jump" coverage="0%" />
                <condition number="263" type="jump" coverage="0%" />
                <condition number="299" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="31" hits="0" branch="False" />
            <line number="33" hits="0" branch="True" condition-coverage="0% (0/2)">
              <conditions>
                <condition number="354" type="jump" coverage="0%" />
              </conditions>
            </line>
            <line number="34" hits="0" branch="False" />
            <line number="35" hits="0" branch="False" />
            <line number="38" hits="0" branch="False" />
            <line number="40" hits="0" branch="False" />
            <line number="41" hits="0" branch="False" />
          </lines>
        </class>
      </classes>
    </package>
  </packages>
</coverage>