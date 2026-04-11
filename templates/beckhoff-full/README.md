This template is a copy from beckhoff-only-wrapper-blocks, with only following difference:

# beckhoff-only-wrapper-blocks:

```
        <inOutVars>
{%- for variable in inoutVars %}
            <variable name="{{ variable.name }}"><type>{%- if variable.isDerived %}<derived name="FB_MTP_{{ variable['Data Type'] }}" />{%- else %}<{{ variable['Data Type'] | upper }} />{%- endif %}</type></variable>
{%- endfor %}
        </inOutVars>
```


# beckhoff-full:

```
        <inOutVars>
{%- for variable in inoutVars %}
            <variable name="{{ variable.name }}"><type>{%- if variable.isDerived %}<derived name="{{ variable['Data Type'] }}" />{%- else %}<{{ variable['Data Type'] | upper }} />{%- endif %}</type></variable>
{%- endfor %}
        </inOutVars>
```

explanation:
In 'only-wrapper-blocks' the standard Beckhoff-provided MTP blocks are used.
These are named with the prefix 'FB_MTP_', and since they are added in the inOutVars and there are no other inOutVars we just add this prefix here.